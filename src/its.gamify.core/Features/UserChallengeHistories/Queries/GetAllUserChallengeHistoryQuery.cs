using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace its.gamify.core.Features.UserChallengeHistories.Queries
{
    public class GetAllUserChallengeHistoryQuery : IRequest<BasePagingResponseModel<UserChallengeHistory>>
    {
        public required Guid UserId { get; set; }
        public FilterQuery? Filter { get; set; }
        class QueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllUserChallengeHistoryQuery, BasePagingResponseModel<UserChallengeHistory>>
        {

            public async Task<BasePagingResponseModel<UserChallengeHistory>> Handle(GetAllUserChallengeHistoryQuery request, CancellationToken cancellationToken)
            {
                Expression<Func<UserChallengeHistory, bool>> filter = x => x.UserId == request.UserId &&
                (string.IsNullOrEmpty(request.Filter!.Q) || x.Status.Contains(request.Filter.Q) 
                    || x.Challenge.Title.Contains(request.Filter.Q));
                var (Pagination, Entities) = await unitOfWork.UserChallengeHistoryRepository
                .ToDynamicPagination(pageIndex: request.Filter?.Page ?? 0,
                    pageSize: request.Filter?.Limit ?? 10,
                    filter: filter,
                    searchFields: ["ChallengeId", "UserId", "Status"], searchTerm: request.Filter?.Q ?? string.Empty,
                    sortOrders: request.Filter?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC"),
                    includeFunc: x => x.Include(x => x.Challenge).Include(x => x.User).Include(x => x.Winner));
                return BasePagingResponseModel<UserChallengeHistory>.CreateInstance(Entities, Pagination);


            }
        }

    }
}
