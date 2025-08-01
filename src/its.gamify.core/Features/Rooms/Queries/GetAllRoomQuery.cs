using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace its.gamify.core.Features.Rooms.Queries
{
    public class GetAllRoomQuery : IRequest<BasePagingResponseModel<Room>>
    {
        public FilterQuery? Filter { get; set; }
        public Guid ChallengeId { get; set; }
        class QueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllRoomQuery, BasePagingResponseModel<Room>>
        {

            public async Task<BasePagingResponseModel<Room>> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
            {

                var (Pagination, Entities) = await unitOfWork.RoomRepository.ToDynamicPagination(
                    pageIndex: request.Filter?.Page ?? 0,
                    pageSize: request.Filter?.Limit ?? 10,
                    sortOrders: request.Filter?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC"),
                    filter: x => x.ChallengeId == request.ChallengeId,
                    includeFunc: x => x
                        .Include(x => x.Challenge)
                        .Include(x => x.HostUser!)
                        .Include(x => x.OpponentUser!)
                    );

                return BasePagingResponseModel<Room>.CreateInstance(Entities, Pagination);

            }
        }

    }
}
