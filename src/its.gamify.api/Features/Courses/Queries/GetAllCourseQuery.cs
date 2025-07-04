using System.Linq.Expressions;
using its.gamify.core;
using its.gamify.core.Features.AvailablesData;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace its.gamify.api.Features.Users.Queries
{

    public class GetAllCourseQuery : IRequest<BasePagingResponseModel<Course>>
    {
        public FilterQuery? filterQuery { get; set; }

        class QueryHandler : IRequestHandler<GetAllCourseQuery, BasePagingResponseModel<Course>>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IClaimsService _claimSerivce;
            public QueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService, Ultils data)
            {
                this.unitOfWork = unitOfWork;
                this._claimSerivce = claimsService;
            }
            public async Task<BasePagingResponseModel<Course>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
            {

                Expression<Func<Course, bool>>? filter = x => x.Status == COURSE_STATUS.PUBLISHED && x.IsDraft == false;

                var res = _claimSerivce.CurrentRole == ROLE.EMPLOYEE
                    ? await unitOfWork.CourseRepository.ToDynamicPagination(request.filterQuery?.Page ?? 0,
                        request.filterQuery?.Limit ?? 10,
                        filter: filter,
                        searchTerm: request.filterQuery?.Q, searchFields: ["Title", "Description", "LongDescription"],
                        sortOrders: request.filterQuery?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC"),
                        includeFunc: x => x.Include(x => x.CourseSections.Where(x => !x.IsDeleted))
                            .Include(x => x.Deparment!)
                            .Include(x => x.Category))
                    : await unitOfWork.CourseRepository.ToDynamicPagination(request.filterQuery?.Page ?? 0,
                        request.filterQuery?.Limit ?? 10,
                        searchTerm: request.filterQuery?.Q, searchFields: ["Title", "Description", "LongDescription"],
                        sortOrders: request.filterQuery?.OrderBy?.ToDictionary(x => x.OrderColumn ?? string.Empty, x => x.OrderDir == "ASC"),
                        includeFunc: x => x.Include(x => x.CourseSections.Where(x => !x.IsDeleted))
                            .Include(x => x.Deparment!)
                            .Include(x => x.Category));

                return new BasePagingResponseModel<Course>(datas: res.Entities, pagination: res.Pagination);
            }

        }

    }

}
