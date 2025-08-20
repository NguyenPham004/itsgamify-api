using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.Rooms.Queries
{
    public class GetRoomByIdQuery : IRequest<Room>
    {
        public Guid Id { get; set; }
        public class QueryHandler(IUnitOfWork unitOfWork, ICurrentTime currentTime) : IRequestHandler<GetRoomByIdQuery, Room>
        {
            private readonly IUnitOfWork unitOfWork = unitOfWork;

            public async Task<Room> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
            {
                var room = await unitOfWork
                    .RoomRepository
                    .GetByIdAsync(
                        request.Id,
                        cancellationToken: cancellationToken,
                        includes: [
                            x => x.Challenge,
                            x => x.HostUser!,
                            x => x.RoomUsers!.Where(x => !x.IsDeleted && !x.IsOutRoom)]
                    ) ?? throw new BadRequestException("Phòng không tồn tại");
                var quarter = await unitOfWork.QuarterRepository
                               .FirstOrDefaultAsync(q => q.StartDate <= currentTime.GetCurrentTime && q.EndDate >= currentTime.GetCurrentTime) ?? throw new BadRequestException("Không tìm thấy quý!");

                if (room.RoomUsers != null)
                {
                    foreach (var roomUser in room.RoomUsers)
                    {
                        roomUser.User = await unitOfWork.UserRepository
                            .GetByIdAsync(
                                roomUser.UserId,
                                includes: x => x.UserMetrics!.Where(x => x.QuarterId == quarter.Id)) ?? null!;
                    }
                }
                return room;
            }
        }
    }
}
