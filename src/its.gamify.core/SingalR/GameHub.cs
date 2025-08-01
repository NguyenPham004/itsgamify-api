using Microsoft.AspNetCore.SignalR;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;  // Giả sử namespace cho Room, History

namespace its.gamify.core.SingalR;

public class GameHub(IUnitOfWork unitOfWork) : Hub
{
    private static readonly Dictionary<string, HashSet<string>> _roomConnections = [];  // roomId -> set of connectionIds
    private static readonly Dictionary<string, string> _connectionToUser = [];  // connectionId -> userId (để biết user nào disconnect)

    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task JoinRoom(string roomId, string userId)
    {
        var room = await _unitOfWork.RoomRepository.GetByIdAsync(Guid.Parse(roomId));
        if (room == null)
        {
            await Clients.Caller.SendAsync("Error", "Room không tồn tại hoặc đã bị xóa.");
            return;
        }

        await Groups.AddToGroupAsync(Context.ConnectionId, $"room_{roomId}");

        // Track connection
        if (!_roomConnections.ContainsKey(roomId)) _roomConnections[roomId] = [];
        _roomConnections[roomId].Add(Context.ConnectionId);
        _connectionToUser[Context.ConnectionId] = userId;

        var userGuid = Guid.Parse(userId);
        var user = await _unitOfWork.UserRepository.GetByIdAsync(userGuid);
        if (room.HostUserId == null)
        {
            room.HostUserId = userGuid;
            _unitOfWork.RoomRepository.Update(room);
            await _unitOfWork.SaveChangesAsync();
        }
        else if (room.OpponentUserId == null && room.HostUserId != userGuid)
        {
            room.OpponentUserId = userGuid;
            room.Status = ROOM_STATUS.FULL;
            _unitOfWork.RoomRepository.Update(room);
            await _unitOfWork.SaveChangesAsync();
        }
        else
        {
            await Clients.Caller.SendAsync("Error", "Phòng đã đầy.");
            return;
        }

        await Clients.Group($"room_{roomId}").SendAsync("UserJoined", user!.FullName);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var connectionId = Context.ConnectionId;
        var userId = _connectionToUser.GetValueOrDefault(connectionId);

        // Tìm room của connection này
        var roomId = _roomConnections.FirstOrDefault(kv => kv.Value.Contains(connectionId)).Key;
        if (roomId != null && userId != null)
        {
            _roomConnections[roomId].Remove(connectionId);
            _connectionToUser.Remove(connectionId);

            var room = await _unitOfWork.RoomRepository.GetByIdAsync(Guid.Parse(roomId));
            if (room != null)
            {
                var userGuid = Guid.Parse(userId);
                bool isHost = room.HostUserId == userGuid;
                bool isOpponent = room.OpponentUserId == userGuid;

                if (isHost)
                {
                    if (room.OpponentUserId != null && _roomConnections[roomId].Count > 0)
                    {
                        room.HostUserId = room.OpponentUserId;
                        room.OpponentUserId = null;
                        _unitOfWork.RoomRepository.Update(room);
                        await _unitOfWork.SaveChangesAsync();
                        await Clients.Group($"room_{roomId}").SendAsync("HostChanged", room.HostUserId.ToString());
                    }
                    else
                    {
                        await SoftDeleteRoom(room);
                    }
                }
                else if (isOpponent)
                {
                    room.OpponentUserId = null;
                    _unitOfWork.RoomRepository.Update(room);
                    await _unitOfWork.SaveChangesAsync();

                    if (_roomConnections[roomId].Count == 0)
                    {
                        await SoftDeleteRoom(room);
                    }
                    else
                    {
                        await Clients.Group($"room_{roomId}").SendAsync("OpponentLeft");
                    }
                }
            }

            if (_roomConnections[roomId].Count == 0) _roomConnections.Remove(roomId);
        }

        await base.OnDisconnectedAsync(exception);
    }

    private async Task SoftDeleteRoom(Room room)
    {
        // Soft delete
        _unitOfWork.RoomRepository.SoftRemove(room);

        // Lưu History nếu game đã bắt đầu (abandoned)
        // if (room.CurrentQuestionIndex > 0)
        // {
        //     var historyHost = new History
        //     {
        //         UserId = room.HostUserId ?? Guid.Empty,
        //         RoomId = room.Id,
        //         TotalPoints = 0,
        //         IsWinner = false
        //     };
        //     var historyOpponent = new History
        //     {
        //         UserId = room.OpponentUserId ?? Guid.Empty,
        //         RoomId = room.Id,
        //         TotalPoints = 0,
        //         IsWinner = false
        //     };
        //     _unitOfWork.HistoryRepository.Add(historyHost);  // Giả sử bạn có HistoryRepository
        //     _unitOfWork.HistoryRepository.Add(historyOpponent);
        // }

        await _unitOfWork.SaveChangesAsync();
    }
}
