using Microsoft.AspNetCore.SignalR;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using Newtonsoft.Json;
using its.gamify.core.Services.Interfaces;
using its.gamify.core.GlobalExceptionHandling.Exceptions;


namespace its.gamify.core.SingalR;

public class GameHub(IUnitOfWork unitOfWork, ICurrentTime currentTime) : Hub
{
    private static readonly Dictionary<string, HashSet<string>> _roomConnections = [];  // roomId -> set of connectionIds
    private static readonly Dictionary<string, string> _connectionToUser = [];  // connectionId -> userId (để biết user nào disconnect)

    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task JoinRoom(string roomId, string userId)
    {
        var userGuid = Guid.Parse(userId);
        var roomGuid = Guid.Parse(roomId);
        var room = await _unitOfWork.RoomRepository.GetByIdAsync(Guid.Parse(roomId));
        if (room == null)
        {
            await Clients.Caller.SendAsync("Error", "Room không tồn tại hoặc đã bị xóa.");
            return;
        }

        if (room.OpponentUserId != null && room.OpponentUserId == userGuid) return;

        await Groups.AddToGroupAsync(Context.ConnectionId, $"room_{roomId}");

        // Track connection
        if (!_roomConnections.ContainsKey(roomId)) _roomConnections[roomId] = [];
        _roomConnections[roomId].Add(Context.ConnectionId);
        _connectionToUser[Context.ConnectionId] = userId;

        var user = await _unitOfWork.UserRepository.GetByIdAsync(userGuid);

        if (room.HostUserId != null && room.OpponentUserId != null) return;

        if (room.HostUserId != null && room.HostUserId == userGuid) return;


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
            await Clients.Group($"room_{roomId}").SendAsync("Notify", $"Người chơi {user!.FullName} đã tham gia!");
        }
        else
        {
            await Clients.Caller.SendAsync("Error", "Phòng đã đầy.");
            return;
        }
        string jsonRoom = await GetRoomJsonAsync(roomGuid);

        await Clients.Group($"room_{roomId}").SendAsync("RoomUpdated", jsonRoom);
    }

    public async Task ReadyToJoin(string roomId, string userId)
    {
        var userGuid = Guid.Parse(userId);
        var roomGuid = Guid.Parse(roomId);
        var room = await _unitOfWork.RoomRepository.GetByIdAsync(Guid.Parse(roomId));
        if (room == null)
        {
            await Clients.Caller.SendAsync("Error", "Room không tồn tại hoặc đã bị xóa.");
            return;
        }

        var user = await _unitOfWork.UserRepository.GetByIdAsync(userGuid);

        if (room.HostUserId == userGuid)
        {
            room.IsHostReady = true;
            _unitOfWork.RoomRepository.Update(room);
            await _unitOfWork.SaveChangesAsync();
            await Clients.Group($"room_{roomId}").SendAsync("Notify", $"Người chơi {user!.FullName} đã sẵn sàng!");
        }

        if (room.OpponentUserId == userGuid)
        {
            room.IsOpponentReady = true;
            _unitOfWork.RoomRepository.Update(room);
            await _unitOfWork.SaveChangesAsync();
            await Clients.Group($"room_{roomId}").SendAsync("Notify", $"Người chơi {user!.FullName} đã sẵn sàng!");
        }


        string jsonRoom = await GetRoomJsonAsync(roomGuid);
        await Clients.Group($"room_{roomId}").SendAsync("RoomUpdated", jsonRoom);
    }

    public async Task UpdateRoom(string roomId)
    {
        var roomGuid = Guid.Parse(roomId);

        string jsonRoom = await GetRoomJsonAsync(roomGuid);

        await Clients.Group($"room_{roomId}").SendAsync("RoomUpdated", jsonRoom);
    }
    public async Task PlayAgain(Guid roomId)
    {
        var room = await _unitOfWork.RoomRepository.GetByIdAsync(roomId);
        if (room == null)
        {
            await Clients.Caller.SendAsync("Error", "Room không tồn tại hoặc đã bị xóa.");
            return;
        }
        if (room.HostUserId == null || room.OpponentUserId == null)
        {
            room.Status = ROOM_STATUS.WAITING;
        }
        else
        {
            room.Status = ROOM_STATUS.FULL;
        }

        _unitOfWork.RoomRepository.Update(room);
        await _unitOfWork.SaveChangesAsync();

        string jsonRoom = await GetRoomJsonAsync(roomId);

        await Clients.Group($"room_{roomId}").SendAsync("RoomUpdated", jsonRoom);
    }

    public async Task SubmitAnswer(Guid roomId, Guid userId, int currentQuestion, int points)
    {
        var room = await _unitOfWork.RoomRepository.GetByIdAsync(roomId);
        if (room == null)
        {
            await Clients.Caller.SendAsync("Error", "Room không tồn tại hoặc đã bị xóa.");
            return;
        }

        if (room.HostUserId == userId)
        {
            room.HostScore += points;
            room.IsHostAnswer = true;
        }
        else if (room.OpponentUserId == userId)
        {
            room.OpponentScore += points;
            room.IsOpponentAnswer = true;
        }

        _unitOfWork.RoomRepository.Update(room);
        await _unitOfWork.SaveChangesAsync();

        string jsonRoom = await GetRoomJsonAsync(roomId);

        await Clients.Group($"room_{roomId}").SendAsync("RoomUpdated", jsonRoom);
    }

    public async Task MoveToNextQuestion(Guid roomId)
    {
        var room = await _unitOfWork.RoomRepository.GetByIdAsync(roomId);
        if (room == null)
        {
            await Clients.Caller.SendAsync("Error", "Room không tồn tại hoặc đã bị xóa.");
            return;
        }

        room.CurrentQuestion += 1;
        room.IsHostAnswer = false;
        room.IsOpponentAnswer = false;

        _unitOfWork.RoomRepository.Update(room);
        await _unitOfWork.SaveChangesAsync();

        string jsonRoom = await GetRoomJsonAsync(roomId);

        await Clients.Group($"room_{roomId}").SendAsync("RoomUpdated", jsonRoom);
    }

    public async Task EndMatch(Guid roomId, Guid userId, int numOfCorrect)
    {
        var room = await _unitOfWork.RoomRepository.GetByIdAsync(roomId);
        if (room == null)
        {
            await Clients.Caller.SendAsync("Error", "Room không tồn tại hoặc đã bị xóa.");
            return;
        }

        if (room.Status == ROOM_STATUS.PLAYING)
        {
            var isTie = room.OpponentScore == room.HostScore;
            await _unitOfWork.UserChallengeHistoryRepository.AddAsync(new UserChallengeHistory
            {
                YourScore = room.HostScore,
                OppScore = room.OpponentScore,
                UserId = room.HostUserId!.Value,
                OpponentId = room.OpponentUserId!.Value,
                ChallengeId = room.ChallengeId,
                AverageCorrect = numOfCorrect / room.QuestionCount,
                Status = room.HostScore > room.OpponentScore
                    ? UserChallengeHistoryEnum.WIN
                    : (isTie ? UserChallengeHistoryEnum.TIE : UserChallengeHistoryEnum.LOSE)
            });


            await _unitOfWork.UserChallengeHistoryRepository.AddAsync(new UserChallengeHistory
            {
                YourScore = room.OpponentScore,
                OppScore = room.HostScore,
                UserId = room.OpponentUserId!.Value,
                OpponentId = room.HostUserId!.Value,
                ChallengeId = room.ChallengeId,
                AverageCorrect = numOfCorrect / room.QuestionCount,
                Status = room.OpponentScore > room.HostScore
                    ? UserChallengeHistoryEnum.WIN
                    : (isTie ? UserChallengeHistoryEnum.TIE : UserChallengeHistoryEnum.LOSE)
            });

            if (!isTie)
            {
                await UpdateUserMetric(room.HostUserId.Value, room.HostScore > room.OpponentScore, room.BetPoints!);
                await UpdateUserMetric(room.OpponentUserId.Value, room.OpponentScore > room.HostScore, room.BetPoints!);
            }
        }

        room.CurrentQuestion = 0;
        room.IsHostAnswer = false;
        room.IsOpponentAnswer = false;
        room.IsHostReady = false;
        room.IsOpponentReady = false;
        room.Status = ROOM_STATUS.FINISHED;
        _unitOfWork.RoomRepository.Update(room);
        await _unitOfWork.SaveChangesAsync();

        string jsonRoom = await GetRoomJsonAsync(roomId);

        await Clients.Group($"room_{roomId}").SendAsync("RoomUpdated", jsonRoom);
    }

    public async Task OutMatch(Guid roomId, Guid userId, int numOfCorrect)
    {
        var room = await _unitOfWork.RoomRepository.GetByIdAsync(roomId);
        if (room == null)
        {
            await Clients.Caller.SendAsync("Error", "Room không tồn tại hoặc đã bị xóa.");
            return;
        }

        if (room.Status == ROOM_STATUS.PLAYING)
        {
            await _unitOfWork.UserChallengeHistoryRepository.AddAsync(new UserChallengeHistory
            {
                YourScore = room.HostScore,
                OppScore = room.OpponentScore,
                UserId = room.HostUserId!.Value,
                OpponentId = room.OpponentUserId!.Value,
                ChallengeId = room.ChallengeId,
                AverageCorrect = numOfCorrect / room.QuestionCount,
                Status = room.HostUserId != userId ? UserChallengeHistoryEnum.WIN : UserChallengeHistoryEnum.LOSE
            });


            await _unitOfWork.UserChallengeHistoryRepository.AddAsync(new UserChallengeHistory
            {
                YourScore = room.OpponentScore,
                OppScore = room.HostScore,
                UserId = room.OpponentUserId!.Value,
                OpponentId = room.HostUserId!.Value,
                ChallengeId = room.ChallengeId,
                AverageCorrect = numOfCorrect / room.QuestionCount,
                Status = room.OpponentUserId != userId ? UserChallengeHistoryEnum.WIN : UserChallengeHistoryEnum.LOSE
            });


            await UpdateUserMetric(room.HostUserId.Value, room.HostUserId != userId, room.BetPoints!);
            await UpdateUserMetric(room.OpponentUserId.Value, room.OpponentUserId != userId, room.BetPoints!);

        }

        room.CurrentQuestion = 0;
        room.IsHostAnswer = false;
        room.IsOpponentAnswer = false;
        room.IsHostReady = false;
        room.IsOpponentReady = false;
        room.Status = ROOM_STATUS.FINISHED;

        if (room.OpponentUserId == null)
        {
            _unitOfWork.RoomRepository.SoftRemove(room);
        }
        else if (room.OpponentUserId == userId)
        {
            room.OpponentUserId = null;
            _unitOfWork.RoomRepository.Update(room);
        }
        else
        {
            if (room.HostUserId == userId)
            {
                room.HostUserId = room.OpponentUserId;
            }
            room.OpponentUserId = null;
            _unitOfWork.RoomRepository.Update(room);

        }

        await _unitOfWork.SaveChangesAsync();

        string jsonRoom = await GetRoomJsonAsync(roomId);

        await Clients.Group($"room_{roomId}").SendAsync("RoomUpdated", jsonRoom);
    }

    public async Task StartMatch(Guid roomId)
    {
        var room = await _unitOfWork.RoomRepository.GetByIdAsync(roomId);
        if (room == null)
        {
            await Clients.Caller.SendAsync("Error", "Room không tồn tại hoặc đã bị xóa.");
            return;
        }

        room.CurrentQuestion = 0;
        room.HostScore = 0;
        room.OpponentScore = 0;
        room.IsHostAnswer = false;
        room.IsOpponentAnswer = false;
        room.IsHostReady = false;
        room.IsOpponentReady = false;
        room.Status = ROOM_STATUS.PLAYING;

        _unitOfWork.RoomRepository.Update(room);
        await _unitOfWork.SaveChangesAsync();

        string jsonRoom = await GetRoomJsonAsync(roomId);

        await Clients.Group($"room_{roomId}").SendAsync("RoomUpdated", jsonRoom);
    }

    private async Task UpdateUserMetric(Guid userId, bool isWinner, int points)
    {
        var quarter = await _unitOfWork.QuarterRepository
               .FirstOrDefaultAsync(q =>
                    q.StartDate <= currentTime.GetCurrentTime &&
                    q.EndDate >= currentTime.GetCurrentTime
                ) ?? throw new BadRequestException("Không tìm thấy quý!");

        var metric = await _unitOfWork.UserMetricRepository.FirstOrDefaultAsync(x => x.UserId == userId && x.QuarterId == quarter.Id)
            ?? throw new NotFoundException("Không tìm thấy chỉ số người dùng!");

        metric.ChallengeParticipateNum += 1;
        metric.PointInQuarter += isWinner ? points : -points;
        metric.WinNum += isWinner ? 1 : 0;
        metric.LoseNum += isWinner ? 1 : 0;
        if (!isWinner)
        {
            metric.HighestWinStreak = metric.WinStreak;
        }
        metric.WinStreak = isWinner ? (metric.WinStreak + 1) : 0;

        _unitOfWork.UserMetricRepository.Update(metric);

    }

    public override Task OnConnectedAsync()
    {
        var connectionId = Context.ConnectionId;
        Console.WriteLine($"New connection: {connectionId}");

        // Log tổng số kết nối hiện tại
        Console.WriteLine($"Total connections: {_connectionToUser.Count}");

        // Log chi tiết các phòng và kết nối
        Console.WriteLine("Room connections:");
        foreach (var room in _roomConnections)
        {
            Console.WriteLine($"Room {room.Key}: {room.Value.Count} connections");
            foreach (var conn in room.Value)
            {
                string userId = _connectionToUser.GetValueOrDefault(conn) ?? "Unknown";
                Console.WriteLine($"  - Connection: {conn}, User: {userId}");
            }
        }

        return Task.CompletedTask;
    }

    public async Task OutRoom(Guid roomId, Guid userId)
    {
        var room = await _unitOfWork.RoomRepository.GetByIdAsync(roomId);
        if (room == null)
        {
            await Clients.Caller.SendAsync("Error", "Room không tồn tại hoặc đã bị xóa.");
            return;
        }
        room.Status = ROOM_STATUS.WAITING;
        room.IsHostReady = false;
        room.IsOpponentReady = false;

        if (room.OpponentUserId == null)
        {
            _unitOfWork.RoomRepository.SoftRemove(room);
        }
        else if (room.OpponentUserId == userId)
        {
            room.OpponentUserId = null;
            _unitOfWork.RoomRepository.Update(room);
        }
        else
        {
            if (room.HostUserId == userId)
            {
                room.HostUserId = room.OpponentUserId;
            }
            room.OpponentUserId = null;
            _unitOfWork.RoomRepository.Update(room);

        }

        await _unitOfWork.SaveChangesAsync();

        string jsonRoom = await GetRoomJsonAsync(roomId);

        await Clients.Group($"room_{roomId}").SendAsync("RoomUpdated", jsonRoom);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var connectionId = Context.ConnectionId;
        var userId = _connectionToUser.GetValueOrDefault(connectionId);

        // Tìm room của connection này
        var roomId = _roomConnections.FirstOrDefault(kv => kv.Value.Contains(connectionId)).Key;
        // if (roomId != null && userId != null)
        // {
        //     _roomConnections[roomId].Remove(connectionId);
        //     _connectionToUser.Remove(connectionId);

        //     var room = await _unitOfWork.RoomRepository.GetByIdAsync(Guid.Parse(roomId));
        //     if (room != null)
        //     {
        //         var userGuid = Guid.Parse(userId);
        //         bool isHost = room.HostUserId == userGuid;
        //         bool isOpponent = room.OpponentUserId == userGuid;

        //         if (isHost)
        //         {
        //             if (room.OpponentUserId != null && _roomConnections[roomId].Count > 0)
        //             {
        //                 room.HostUserId = room.OpponentUserId;
        //                 room.OpponentUserId = null;
        //                 _unitOfWork.RoomRepository.Update(room);
        //                 await _unitOfWork.SaveChangesAsync();
        //                 await Clients.Group($"room_{roomId}").SendAsync("HostChanged", room.HostUserId.ToString());
        //             }
        //             else
        //             {
        //                 await SoftDeleteRoom(room);
        //             }
        //         }
        //         else if (isOpponent)
        //         {
        //             room.OpponentUserId = null;
        //             _unitOfWork.RoomRepository.Update(room);
        //             await _unitOfWork.SaveChangesAsync();

        //             if (_roomConnections[roomId].Count == 0)
        //             {
        //                 await SoftDeleteRoom(room);
        //             }
        //             else
        //             {
        //                 await Clients.Group($"room_{roomId}").SendAsync("OpponentLeft");
        //             }
        //         }
        //     }

        //     if (_roomConnections[roomId].Count == 0) _roomConnections.Remove(roomId);
        // }

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

    private async Task<string> GetRoomJsonAsync(Guid id)
    {
        return JsonConvert.SerializeObject(await _unitOfWork
            .RoomRepository
            .GetByIdAsync(
                id,
                includes: [x => x.Challenge, x => x.HostUser!, x => x.OpponentUser!]
            ), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver
                {
                    NamingStrategy = new Newtonsoft.Json.Serialization.SnakeCaseNamingStrategy()
                }
            });
    }
}
