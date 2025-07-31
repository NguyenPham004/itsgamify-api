using its.gamify.core.Features.Challenges.Queries;
using its.gamify.domains.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Features.Rooms.Queries
{
    public class GetRoomByIdQuery : IRequest<Room>
    {
        public Guid Id { get; set; }
        public class QueryHandler : IRequestHandler<GetRoomByIdQuery, Room>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<Room> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
            {
                return (await unitOfWork.RoomRepository.GetByIdAsync(request.Id, cancellationToken: cancellationToken, includes: x => x.Challenge)) ?? throw new InvalidOperationException("Phòng không tồn tại");
            }
        }
    }
}
