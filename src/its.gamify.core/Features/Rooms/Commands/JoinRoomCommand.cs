using FluentValidation;
using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models.Rooms;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using MediatR;

namespace its.gamify.core.Features.Rooms.Commands
{
    public class JoinRoomCommand : IRequest<Room>
    {
        public Guid RoomId { get; set; }
        public required JoinRoomModel Model { get; set; }
        class CommandHandler(IUnitOfWork unitOfWork, IClaimsService claims) : IRequestHandler<JoinRoomCommand, Room>
        {
            public async Task<Room> Handle(JoinRoomCommand request, CancellationToken cancellationToken)
            {
                var room = await unitOfWork.RoomRepository
                .GetByIdAsync(request.RoomId, includes:
                    x => x.RoomUsers!.Where(x => !x.IsDeleted && !x.IsOutRoom))
                    ?? throw new BadRequestException("Phòng chờ không tồn tại!");

                if (room.Status != ROOM_STATUS.WAITING) throw new BadRequestException("Phòng chờ không khả dụng!");

                if (room.RoomUsers != null && room.RoomUsers.Count > room.MaxPlayers) throw new BadRequestException("Phòng chờ đã đầy!");

                if (room.RoomCode != request.Model.RoomCode) throw new BadRequestException("Mã phòng không hợp lệ!");

                var roomUser = new RoomUser
                {
                    RoomId = room.Id,
                    UserId = claims.CurrentUser,
                    IsOutRoom = false,
                    CurrentScore = 0,
                    CorrectAnswers = 0,
                    IsCurrentQuestionAnswered = false
                };
                room.Status = room.RoomUsers!.Count + 1 >= room.MaxPlayers ? ROOM_STATUS.FULL : ROOM_STATUS.WAITING;

                unitOfWork.RoomRepository.Update(room);
                await unitOfWork.RoomUserRepository.AddAsync(roomUser, cancellationToken);
                await unitOfWork.SaveChangesAsync();

                return room;
            }
        }
    }
}
