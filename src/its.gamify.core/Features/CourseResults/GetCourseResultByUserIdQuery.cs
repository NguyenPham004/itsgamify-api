using System.Linq.Expressions;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.CourseResults
{
    public class GetCourseResultByUserIdQuery : IRequest<BasePagingResponseModel<CourseResult>>
    {
        public required Guid UserId { get; set; }
        public required FilterQuery FilterQuery { get; set; }

        public class QueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetCourseResultByUserIdQuery, BasePagingResponseModel<CourseResult>>
        {

            public async Task<BasePagingResponseModel<CourseResult>> Handle(GetCourseResultByUserIdQuery request, CancellationToken cancellationToken)
            {
                Expression<Func<CourseResult, bool>> filter = x =>
                    x.UserId == request.UserId &&
                    (string.IsNullOrEmpty(request.FilterQuery.Q) || x.Course.Title.Contains(request.FilterQuery.Q!));

                var (Pagination, Entities) = await _unitOfWork.CourseResultRepository.ToPagination(
                    pageIndex: request.FilterQuery.Page ?? 0,
                    pageSize: request.FilterQuery.Limit ?? 10,
                    filter: filter,
                    includes: [x => x.User, x => x.Course, x => x.CourseParticipation],
                    cancellationToken: cancellationToken);
                return new BasePagingResponseModel<CourseResult>(Entities, Pagination);
            }
        }
    }
}
