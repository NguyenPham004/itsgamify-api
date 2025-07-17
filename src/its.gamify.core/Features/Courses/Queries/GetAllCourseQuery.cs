using System.Linq.Expressions;
using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using its.gamify.core.Utilities;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using its.gamify.domains.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;



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
        IClaimsService _claimSerivce
    ) : IRequestHandler<GetAllCourseQuery, BasePagingResponseModel<Course>>
    {

        public async Task<BasePagingResponseModel<Course>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {


            Expression<Func<Course, bool>>? filter = null;

            Dictionary<string, bool>? sortOrders = request.CourseQuery?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC");

            Func<IQueryable<Course>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Course, object>>? includeFunc =
                x =>
                    x.Include(x => x.CourseSections.Where(x => !x.IsDeleted))
                    .Include(x => x.Deparment!)
                    .Include(x => x.Category);

            (Pagination Pagination, List<Course> Entities)? res = null;
            var user = await unitOfWork.UserRepository.GetByIdAsync(_claimSerivce.CurrentUser) ?? throw new Exception("Can not find user");


            if (_claimSerivce.CurrentRole == ROLE.EMPLOYEE)
            {
                filter = x => x.Status == COURSE_STATUS.PUBLISHED &&
                   x.IsDraft == false &&
                   (x.CourseType == COURSE_TYPE.ALL || (x.CourseType == COURSE_TYPE.DEPARTMENTONLY && x.DepartmentId == user.DepartmentId)) ;
                res = await unitOfWork.CourseRepository.ToDynamicPagination(request.CourseQuery?.Page ?? 0,
                    request.CourseQuery?.Limit ?? 10,
                    filter: filter,
                    sortOrders: request.CourseQuery?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC"),
                    includeFunc: x => x.Include(x => x.CourseSections.Where(x => !x.IsDeleted))
                        .Include(x => x.CourseParticipations.Where(x => x.UserId == user.Id))
                        .Include(x => x.Deparment!)
                        .Include(x => x.Category));

            }

            else if (_claimSerivce.CurrentRole == ROLE.LEADER)
            {
                filter = x => x.Status == COURSE_STATUS.PUBLISHED &&
                            x.IsDraft == false &&
                            x.DepartmentId == user.DepartmentId;

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
                if (request.CourseQuery?.Classify == COURSE_CLASSIFY.ENROLLED.ToString())
                {
                    Expression<Func<Course, bool>> filter_enrolled = x => x.CourseParticipations.Any(u => u.Status == CourseParticipationStatusEnum.ENROLLED.ToString());
                    filter = filter != null ? FilterCustom.CombineFilters(filter, filter_enrolled) : filter_enrolled;
                }
                else if (request.CourseQuery?.Classify == COURSE_CLASSIFY.SAVED.ToString())
                {
                    List<Guid> collections = (await unitOfWork.CourseCollectionRepository.GetAllAsync()).Where(x => x.UserId == user.Id).Select(x => x.UserId).ToList();
                    Expression<Func<Course, bool>> filter_saved = x => collections != null && collections.Count != 0 && collections.Contains(user.Id);
                    filter = filter != null ? FilterCustom.CombineFilters(filter, filter_saved) : filter_saved;
                }
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

    }

}


