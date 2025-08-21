using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using MediatR;
using System.Linq.Expressions;

namespace its.gamify.core.Features.CourseResults
{
    public class GetCourseResultByUserIdQuery : IRequest<BasePagingResponseModel<CourseResult>>
    {
        public required Guid UserId { get; set; }
        public required CourseResultByUserModel FilterQuery { get; set; }

        public class QueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetCourseResultByUserIdQuery, BasePagingResponseModel<CourseResult>>
        {

            public async Task<BasePagingResponseModel<CourseResult>> Handle(GetCourseResultByUserIdQuery request, CancellationToken cancellationToken)
            {
                Expression<Func<CourseResult, bool>> filter = x =>
                    x.UserId == request.UserId &&
                    (string.IsNullOrEmpty(request.FilterQuery.Q) || x.Course.Title.Contains(request.FilterQuery.Q!));
                if(request.FilterQuery.FilterString == CourseResultsFilterEnum.COMPLETEDDATE)
                {
                    var courseCompleted = await _unitOfWork.CourseParticipationRepository.WhereAsync(x=>x.Status == COURSE_PARTICIPATION_STATUS.COMPLETED);
                    Expression<Func<CourseResult, bool>> filter_combined = x => courseCompleted.Select(y => y.CourseId).Contains(x.CourseId);
                }
                List<(Expression<Func<CourseResult, object>>, bool)> orderByList = new();

                // Chỉ sort theo course name khi FilterValue = "COURSENAME"
                if (request.FilterQuery.FilterString == CourseResultsFilterEnum.COURSENAME)
                {
                    orderByList.Add((x => x.Course.Title, true));
                }
                else
                {
                    // Default ordering
                    orderByList.Add((x => x.CompletedDate, false)); // Mới nhất trước
                }
                var (Pagination, Entities) = await _unitOfWork.CourseResultRepository.ToPagination(
                    pageIndex: request.FilterQuery.Page ?? 0,
                    pageSize: request.FilterQuery.Limit ?? 10,
                    filter: filter,
                    orderByList: orderByList,
                    includes: [x => x.User, x => x.Course, x => x.CourseParticipation],
                    cancellationToken: cancellationToken);
                return new BasePagingResponseModel<CourseResult>(Entities, Pagination);
            }
        }
    }
}
