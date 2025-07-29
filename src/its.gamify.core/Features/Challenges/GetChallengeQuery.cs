using Amazon.S3.Model;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace its.gamify.core.Features.Challenges.Queries
{
    public class GetChallengeQuery : IRequest<BasePagingResponseModel<Challenge>>
    {
        public FilterQuery? Filter { get; set; }
        public class QueryHandler : IRequestHandler<GetChallengeQuery, BasePagingResponseModel<Challenge>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<Challenge>> Handle(GetChallengeQuery request, CancellationToken cancellationToken)
            {
                Expression<Func<Challenge, bool>>? filter = null;
                Dictionary<string, bool>? sortOrders = request.Filter?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC");
                Func<IQueryable<Challenge>, IIncludableQueryable<Challenge, object>>? includeFunc =
                x =>
                    x.Include(x => x.Course);
                var items = await unitOfWork.ChallengeRepository.ToDynamicPagination(request.Filter?.Page ?? 0,
                                                                                    request.Filter?.Limit ?? 10, 
                                                                                    filter:filter,
                                                                                    searchTerm: request.Filter?.Q,
                                                                                    searchFields: ["Title", "Description"],
                                                                                    sortOrders: sortOrders,
                                                                                    includeFunc: includeFunc
                                                                                    );
                return new BasePagingResponseModel<Challenge>(items.Entities, items.Pagination);
            }
        }
    }
}
