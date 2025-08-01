using its.gamify.core.Models.ShareModels;
using its.gamify.core.Utilities;
using its.gamify.domains.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace its.gamify.core.Features.Challenges
{

    public class ChallengeQuery : FilterQuery
    {
        public string? Categories { get; set; } = string.Empty;
    }

    public class GetChallengeQuery : IRequest<BasePagingResponseModel<Challenge>>
    {
        public ChallengeQuery? Filter { get; set; }

        public class QueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetChallengeQuery, BasePagingResponseModel<Challenge>>
        {

            public async Task<BasePagingResponseModel<Challenge>> Handle(GetChallengeQuery request, CancellationToken cancellationToken)
            {
                Expression<Func<Challenge, bool>>? filter = null;
                Dictionary<string, bool>? sortOrders = request.Filter?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC");

                Func<IQueryable<Challenge>, IIncludableQueryable<Challenge, object>>? includeFunc =
                x =>
                    x.Include(x => x.Course).Include(x => x.Category!);

                if (!string.IsNullOrEmpty(request.Filter!.Categories))
                {
                    var categoryIds = JsonConvert.DeserializeObject<List<Guid>>(request.Filter!.Categories!);
                    if (categoryIds != null && categoryIds.Count != 0)
                    {
                        Expression<Func<Challenge, bool>> filter_cate = x => categoryIds != null && categoryIds.Count != 0 && categoryIds.Contains(x.CategoryId);
                        filter = filter != null ? FilterCustom.CombineFilters(filter, filter_cate) : filter_cate;
                    }
                }


                var (Pagination, Entities) = await unitOfWork
                                .ChallengeRepository
                                .ToDynamicPagination(request.Filter?.Page ?? 0,
                                    request.Filter?.Limit ?? 10,
                                    filter: filter,
                                    searchTerm: request.Filter?.Q,
                                    searchFields: ["Title", "Description"],
                                    sortOrders: sortOrders,
                                    includeFunc: x =>
                                        x.Include(x => x.Course).Include(x => x.Category!)
                                );
                return new BasePagingResponseModel<Challenge>(Entities, Pagination);
            }
        }
    }
}
