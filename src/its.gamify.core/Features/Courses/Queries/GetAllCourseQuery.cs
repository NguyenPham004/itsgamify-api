using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using its.gamify.core.Utilities;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using its.gamify.domains.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using System.Linq.Expressions;



namespace its.gamify.core.Features.Courses.Queries;

public class CourseQuery : FilterQuery
{
    public string? Classify { get; set; } = string.Empty;
    public string? Categories { get; set; } = string.Empty;
}
public class GetAllCourseQuery : IRequest<BasePagingResponseModel<Course>>
{
    public CourseQuery? CourseQuery { get; set; }

    class QueryHandler(
        IUnitOfWork unitOfWork,
        IClaimsService _claimSerivce,
        ICurrentTime currentTime
    ) : IRequestHandler<GetAllCourseQuery, BasePagingResponseModel<Course>>
    {

        public async Task<BasePagingResponseModel<Course>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Course, bool>>? filter = null;
            var quarter = await unitOfWork.QuarterRepository.FirstOrDefaultAsync(x=>x.StartDate<= currentTime.GetCurrentTime && x.EndDate>= currentTime.GetCurrentTime);
            Dictionary<string, bool>? sortOrders = request.CourseQuery?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC");

            Func<IQueryable<Course>, IIncludableQueryable<Course, object>>? includeFunc =
                x =>
                    x.Include(x => x.CourseSections.Where(x => !x.IsDeleted))
                    .Include(x => x.Deparment!)
                    .Include(x => x.Category);

            (Pagination Pagination, List<Course> Entities)? res = null;

            var user = await unitOfWork.UserRepository.GetByIdAsync(_claimSerivce.CurrentUser) ?? throw new BadRequestException("Không tìm thấy người dùng!");


            if (_claimSerivce.CurrentRole == ROLE.EMPLOYEE)
            {
                filter = x => x.Status == COURSE_STATUS.PUBLISHED &&
                    x.IsDraft == false && x.QuarterId == quarter.Id &&
                    (x.CourseType == COURSE_TYPE.ALL || 
                        (x.CourseType == COURSE_TYPE.DEPARTMENTONLY 
                         && x.DepartmentId == user.DepartmentId 
                         && x.Status == COURSE_STATUS.PUBLISHED 
                         &&x.IsDraft == false));
                includeFunc = x => x.Include(x => x.CourseSections.Where(x => !x.IsDeleted))
                        .Include(x => x.CourseParticipations.Where(x => x.UserId == user.Id))
                        .Include(x => x.Deparment!)
                        .Include(x => x.Category);

            }

            else if (_claimSerivce.CurrentRole == ROLE.LEADER)
            {
                filter = x => x.Status == COURSE_STATUS.PUBLISHED &&
                            x.IsDraft == false && x.QuarterId == quarter.Id
                            || (x.DepartmentId == user.DepartmentId 
                                && x.CourseType == CourseTypeEnum.DEPARTMENTONLY.ToString() 
                                && x.Status == COURSE_STATUS.PUBLISHED &&
                                x.IsDraft == false);

                includeFunc = x => x.Include(x => x.CourseSections.Where(x => !x.IsDeleted))
                        .Include(x => x.Deparment!)
                        .Include(x => x.Category);
            }

            if (!string.IsNullOrEmpty(request.CourseQuery?.Categories))
            {
                var categoryIds = JsonConvert.DeserializeObject<List<Guid>>(request.CourseQuery.Categories);
                if (categoryIds != null && categoryIds.Count != 0)
                {
                    Expression<Func<Course, bool>> filter_cate = x => categoryIds != null && categoryIds.Count != 0 && categoryIds.Contains(x.CategoryId);
                    filter = filter != null ? FilterCustom.CombineFilters(filter, filter_cate) : filter_cate;
                }
            }

            if (!string.IsNullOrEmpty(request.CourseQuery?.Classify) && (_claimSerivce.CurrentRole == ROLE.EMPLOYEE || _claimSerivce.CurrentRole == ROLE.LEADER))
            {
                Expression<Func<Course, bool>> filter_classify = await ClassifyFunc(request.CourseQuery?.Classify, user.Id);
                filter = filter != null ? FilterCustom.CombineFilters(filter, filter_classify) : filter_classify;

            }

            res = await unitOfWork.CourseRepository.ToDynamicPagination(
                              request.CourseQuery?.Page ?? 0,
                              request.CourseQuery?.Limit ?? 10,
                              filter: filter,
                              searchTerm: request.CourseQuery?.Q, searchFields: ["Title", "Description", "LongDescription"],
                              sortOrders: sortOrders,
                              includeFunc: includeFunc
                        );

            return new BasePagingResponseModel<Course>(datas: res.Value.Entities, pagination: res.Value.Pagination);
        }
        private async Task<Expression<Func<Course, bool>>> ClassifyFunc(string? value, Guid UserId)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return x => true;
            }

            if (value == COURSE_CLASSIFY.ENROLLED.ToString())
            {
                return x => x.CourseParticipations.Any(u => u.Status == CourseParticipationStatusEnum.ENROLLED.ToString());
            }
            else if (value == COURSE_CLASSIFY.SAVED.ToString())
            {
                if (UserId == Guid.Empty) return x => true;
                List<Guid> collections = (await unitOfWork.CourseCollectionRepository.GetAllAsync()).Where(x => x.UserId == UserId).Select(x => x.UserId).ToList();
                return x => collections != null && collections.Count != 0 && collections.Contains(UserId);
            }
            else if (value == COURSE_CLASSIFY.COMPLETED.ToString())
            {
                return x => x.CourseParticipations.Any(u => u.Status == CourseParticipationStatusEnum.COMPLETED.ToString());
            }
            return x => true;
        }

    }

}


