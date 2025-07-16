using its.gamify.api.Features.Users.Queries;
using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using its.gamify.domains.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace its.gamify.api.Features.Courses.Queries
{
    public class ClassifyCourseQuery : IRequest<BasePagingResponseModel<Course>>
    {
        public string Classfy { get; set; } = string.Empty;
        public FilterQuery? FilterQuery { get; set; }

        class QueryHandler : IRequestHandler<ClassifyCourseQuery, BasePagingResponseModel<Course>>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IClaimsService _claimSerivce;
            public QueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService)
            {
                this.unitOfWork = unitOfWork;
                this._claimSerivce = claimsService;
            }
            public async Task<BasePagingResponseModel<Course>> Handle(ClassifyCourseQuery request, CancellationToken cancellationToken)
            {

                Expression<Func<Course, bool>>? filter = null;

                (Pagination Pagination, List<Course> Entities)? res = null;
                var user = await unitOfWork.UserRepository.GetByIdAsync(_claimSerivce.CurrentUser) ?? throw new Exception("Can not find user");

                if (_claimSerivce.CurrentRole == ROLE.EMPLOYEE)
                {
                    if (request.Classfy == COURSE_CLASSIFY.ENROLLED.ToString())
                    {
                        filter = x => x.Status == COURSE_STATUS.PUBLISHED &&
                        x.IsDraft == false &&
                        (x.CourseType == COURSE_TYPE.ALL || (x.CourseType == COURSE_TYPE.DEPARTMENTONLY && x.DepartmentId == user.DepartmentId)) &&
                        x.CourseParticipations.Any(u => u.UserId == user.Id && u.Status == CourseParticipationStatusEnum.ENROLLED.ToString());
                    }
                    else if (request.Classfy == COURSE_CLASSIFY.SAVED.ToString())
                    {
                        List<CourseCollection> collections = (await unitOfWork.CourseCollectionRepository.GetAllAsync()).Where(x => x.UserId == user.Id).ToList();

                        filter = x => x.Status == COURSE_STATUS.PUBLISHED &&
                        x.IsDraft == false &&
                        (x.CourseType == COURSE_TYPE.ALL || (x.CourseType == COURSE_TYPE.DEPARTMENTONLY && x.DepartmentId == user.DepartmentId)) &&
                        x.CourseParticipations.Any(u => u.UserId == user.Id)
                        && collections.Any(x => x.UserId == user.Id);
                    }
                    else
                    {
                        filter = x => x.Status == COURSE_STATUS.PUBLISHED &&
                    x.IsDraft == false &&
                   (x.CourseType == COURSE_TYPE.ALL || (x.CourseType == COURSE_TYPE.DEPARTMENTONLY && x.DepartmentId == user.DepartmentId)) &&
                   x.CourseParticipations.Any(u => u.UserId == user.Id);
                    }
                    res = await unitOfWork.CourseRepository.ToDynamicPagination(request.FilterQuery?.Page ?? 0,
                        request.FilterQuery?.Limit ?? 10,
                        filter: filter,
                        sortOrders: request.FilterQuery?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC"),
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

                    res = await unitOfWork.CourseRepository.ToDynamicPagination(request.FilterQuery?.Page ?? 0,
                        request.FilterQuery?.Limit ?? 10,
                        filter: filter,
                        searchTerm: request.FilterQuery?.Q, searchFields: ["Title", "Description", "LongDescription"],
                        sortOrders: request.FilterQuery?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC"),
                        includeFunc: x => x.Include(x => x.CourseSections.Where(x => !x.IsDeleted))
                            .Include(x => x.Deparment!)
                            .Include(x => x.Category));
                }

                else
                {
                    res = await unitOfWork.CourseRepository.ToDynamicPagination(request.FilterQuery?.Page ?? 0,
                    request.FilterQuery?.Limit ?? 10,
                    searchTerm: request.FilterQuery?.Q, searchFields: ["Title", "Description", "LongDescription"],
                    sortOrders: request.FilterQuery?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC"),
                    includeFunc: x => x.Include(x => x.CourseSections.Where(x => !x.IsDeleted))
                        .Include(x => x.Deparment!)
                        .Include(x => x.Category));
                }

                return new BasePagingResponseModel<Course>(datas: res.Value.Entities, pagination: res.Value.Pagination);
            }

        }

    }
}
