using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.CourseMetrics
{
    public class GetAllCourseMetricQuery : IRequest<BasePagingResponseModel<CourseMetric>>
    {
        public FilterQuery? filterQuery { get; set; }
        public class QueryHandler : IRequestHandler<GetAllCourseMetricQuery, BasePagingResponseModel<CourseMetric>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<CourseMetric>> Handle(GetAllCourseMetricQuery request, CancellationToken cancellationToken)
            {
                var items = await unitOfWork.CourseMetricRepository.ToDynamicPagination(pageIndex: request.filterQuery?.Page ?? 0,
                    pageSize: request.filterQuery?.Limit ?? 10,
                    searchFields: ["Name"], searchTerm: request.filterQuery?.Q ?? string.Empty,
                    sortOrders: request.filterQuery?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC"));
                return new BasePagingResponseModel<CourseMetric>(items.Entities, items.Pagination);
            }
        }
    }
}
