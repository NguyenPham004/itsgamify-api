using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.Rooms.Queries
{
    public class GetRoomByIdQuery : IRequest<Room>
    {
        public Guid Id { get; set; }
        public class QueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetRoomByIdQuery, Room>
        {
            private readonly IUnitOfWork unitOfWork = unitOfWork;

            public async Task<Room> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
            {
                return await unitOfWork
                    .RoomRepository
                    .GetByIdAsync(
                        request.Id,
                        cancellationToken: cancellationToken,
                        includes: [x => x.Challenge, x => x.HostUser!, x => x.OpponentUser!]
                    ) ?? throw new BadRequestException("Phòng không tồn tại");
            }
        }
    }
}
