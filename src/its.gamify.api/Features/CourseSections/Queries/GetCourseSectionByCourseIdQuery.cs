using its.gamify.core;
using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
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
        class QueryHandler : IRequestHandler<GetCourseSectionByCourseIdQuery, BasePagingResponseModel<CourseSection>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<BasePagingResponseModel<CourseSection>> Handle(GetCourseSectionByCourseIdQuery request, CancellationToken cancellationToken)
            {
                List<(Expression<Func<CourseSection, object>> OrderBy, bool IsDescending)>? orderByList = [(x => x.OrderedNumber, false)];
                var res = await unitOfWork.CourseSectionRepository.ToDynamicPagination(
                      pageIndex: request.PageIndex,
                      pageSize: 1000,
                      filter: x => x.CourseId == request.CourseId,
                      includeFunc: x => x.Include(x => x.Lessons.Where(x => !x.IsDeleted))
                                            .ThenInclude(x => x.Quizzes.Where(x => !x.IsDeleted))
                                                .ThenInclude(q => q.Questions.Where(x => !x.IsDeleted))
                                        .Include(x => x.Lessons.Where(x => !x.IsDeleted))
                                            .ThenInclude(x => x.Practices.Where(x => !x.IsDeleted)));
                return new BasePagingResponseModel<CourseSection>(res.Entities, res.Pagination);
            }
        }
    }
}
