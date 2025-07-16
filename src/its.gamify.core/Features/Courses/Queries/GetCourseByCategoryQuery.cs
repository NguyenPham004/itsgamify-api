using its.gamify.api.Features.Questions.Queries;
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
    public class GetCourseByCategoryQuery : IRequest<BasePagingResponseModel<Course>>
    {
        public FilterQuery? FilterQuery { get; set; }
        public Guid CategoryId { get; set; }

        class QueryHandler : IRequestHandler<GetCourseByCategoryQuery, BasePagingResponseModel<Course>>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IClaimsService _claimSerivce;
            public QueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService)
            {
                this.unitOfWork = unitOfWork;
                this._claimSerivce = claimsService;
            }
            public async Task<BasePagingResponseModel<Course>> Handle(GetCourseByCategoryQuery request, CancellationToken cancellationToken)
            {

                Expression<Func<Course, bool>>? filter = null;

                (Pagination Pagination, List<Course> Entities)? res = null;
                var user = await unitOfWork.UserRepository.GetByIdAsync(_claimSerivce.CurrentUser) ?? throw new Exception("Can not find user");

                if (_claimSerivce.CurrentRole == ROLE.EMPLOYEE)
                {
                    filter = x => x.Status == COURSE_STATUS.PUBLISHED &&
                    x.IsDraft == false &&
                   (x.CourseType == COURSE_TYPE.ALL || (x.CourseType == COURSE_TYPE.DEPARTMENTONLY && x.DepartmentId == user.DepartmentId)) &&
                   x.CategoryId == request.CategoryId;

                    res = await unitOfWork.CourseRepository.ToDynamicPagination(request.FilterQuery?.Page ?? 0,
                        request.FilterQuery?.Limit ?? 10,
                        filter: filter,
                        searchTerm: request.FilterQuery?.Q, searchFields: ["Title", "Description", "LongDescription"],
                        sortOrders: request.FilterQuery?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC"),
                        includeFunc: x => x.Include(x => x.CourseSections.Where(x => !x.IsDeleted))
                            .Include(x => x.CourseParticipations.Where(x => x.UserId == user.Id))
                            .Include(x => x.Deparment!)
                            .Include(x => x.Category));
                }

                return new BasePagingResponseModel<Course>(datas: res.Value.Entities, pagination: res.Value.Pagination);
            }

        }

    }
}
