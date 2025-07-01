using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.CourseCollections.Queries
{
    public class GetCourseCollectionQuery : IRequest<BasePagingResponseModel<CourseCollection>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public class QueryHandler : IRequestHandler<GetCourseCollectionQuery, BasePagingResponseModel<CourseCollection>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<CourseCollection>> Handle(GetCourseCollectionQuery request, CancellationToken cancellationToken)
            {
                var items = await unitOfWork.CourseCollectionRepository.ToPagination(
                    pageIndex: request.PageIndex,
                    pageSize: request.PageSize,
                    includes: [x => x.Course, x => x.User],
                    cancellationToken: cancellationToken);
                return new BasePagingResponseModel<CourseCollection>(items.Entities, items.Pagination);
            }
        }
    }
}
