using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using its.gamify.domains.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace its.gamify.api.Features.CourseSections.Queries
{
    public class GetCourseSectionByCourseIdQuery : IRequest<BasePagingResponseModel<CourseSection>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public Guid CourseId { get; set; } = Guid.Empty;
        class QueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<GetCourseSectionByCourseIdQuery, BasePagingResponseModel<CourseSection>>
        {
            private readonly IUnitOfWork _unitOfWork = unitOfWork;
            private readonly IClaimsService _claimsService = claimsService;

            public async Task<BasePagingResponseModel<CourseSection>> Handle(GetCourseSectionByCourseIdQuery request, CancellationToken cancellationToken)
            {
                List<(Expression<Func<CourseSection, object>> OrderBy, bool IsDescending)>? orderByList = [(x => x.OrderedNumber, false)];

                (Pagination Pagination, List<CourseSection> Entities)? res = null;

                if (_claimsService.CurrentRole == ROLE.EMPLOYEE)
                {
                    res = await _unitOfWork.CourseSectionRepository.ToDynamicPagination(
                        pageIndex: request.PageIndex,
                        pageSize: 1000,
                        filter: x => x.CourseId == request.CourseId,
                        includeFunc: x => x.Include(x => x.Lessons.Where(x => !x.IsDeleted))
                                            .ThenInclude(x => x.Quiz)
                                                .ThenInclude(q => q!.Questions.Where(x => !x.IsDeleted))
                                        .Include(x => x.Lessons.Where(x => !x.IsDeleted))
                                            .ThenInclude(x => x.Practices.Where(x => !x.IsDeleted))
                        );
                }
                else
                {
                    res = await _unitOfWork.CourseSectionRepository.ToDynamicPagination(
                        pageIndex: request.PageIndex,
                        pageSize: 1000,
                        filter: x => x.CourseId == request.CourseId,
                        includeFunc: x => x.Include(x => x.Lessons.Where(x => !x.IsDeleted))
                                            .ThenInclude(x => x.Quiz)
                                                .ThenInclude(q => q!.Questions.Where(x => !x.IsDeleted))
                                        .Include(x => x.Lessons.Where(x => !x.IsDeleted))
                                            .ThenInclude(x => x.Practices.Where(x => !x.IsDeleted)));
                }
                return new BasePagingResponseModel<CourseSection>(res.Value.Entities, res.Value.Pagination);
            }
        }
    }
}
