using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace its.gamify.core.Features.CourseCollections.Queries
{
    public class GetAllCourseCollectionQuery : IRequest<BasePagingResponseModel<CourseCollection>>
    {
        public FilterQuery? FilterQuery { get; set; }
        public class QueryHandler : IRequestHandler<GetAllCourseCollectionQuery, BasePagingResponseModel<CourseCollection>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<CourseCollection>> Handle(GetAllCourseCollectionQuery request, CancellationToken cancellationToken)
            {
                var items = await unitOfWork.CourseCollectionRepository.ToDynamicPagination(pageIndex: request.FilterQuery?.Page ?? 0,
                    pageSize: request.FilterQuery?.Limit ?? 10,
                    searchFields: ["Name"], searchTerm: request.FilterQuery?.Q ?? string.Empty,
                    sortOrders: request.FilterQuery?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC"), includeFunc: x => x.Include(x => x.User));
                return new BasePagingResponseModel<CourseCollection>(items.Entities, items.Pagination);
            }
        }
    }
}
