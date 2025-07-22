using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using its.gamify.domains.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace its.gamify.core.Features.LearningProgresses.Queries
{
    public class GetLearningProgressQuery : IRequest<BasePagingResponseModel<LearningProgress>>
    {
        public FilterQuery? Filter { get; set; }
        public class QueryHandler : IRequestHandler<GetLearningProgressQuery, BasePagingResponseModel<LearningProgress>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<LearningProgress>> Handle(GetLearningProgressQuery request, CancellationToken cancellationToken)
            {
                (Pagination Pagination, List<LearningProgress> Entities)? res = null;
                Expression<Func<LearningProgress, bool>>? filter = null;
                Dictionary<string, bool>? sortOrders = request.Filter?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC");

                Func<IQueryable<LearningProgress>, IIncludableQueryable<LearningProgress, object>>? includeFunc =
                    x =>
                        x
                        .Include(x => x.Lesson!)
                        .Include(x => x.QuizResult!)
                        .Include(x => x.CourseParticipation);
                res = await unitOfWork.LearningProgressRepository.ToDynamicPagination(
                              request.Filter?.Page ?? 0,
                              request.Filter?.Limit ?? 10,
                              filter: filter,
                              searchTerm: request.Filter?.Q, searchFields: ["Status", "LastAccessed"],
                              sortOrders: sortOrders,
                              includeFunc: includeFunc
                        );
                return new BasePagingResponseModel<LearningProgress>(datas: res.Value.Entities, pagination: res.Value.Pagination);
            }
        }
    }
}
