using its.gamify.core;
using its.gamify.domains.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace its.gamify.api.Features.Courses.Queries
{
    public class GetCourseByIdQuery : IRequest<Course>
    {
        public Guid Id { get; set; }
        class QueryHandler : IRequestHandler<GetCourseByIdQuery, Course>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<Course> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
            {
                return (await unitOfWork.CourseRepository.FirstOrDefaultAsync(x => x.Id == request.Id, false, cancellationToken,
                    includeFunc: x => x.Include(course => course.LearningMaterials.Where(x => !x.IsDeleted))
                        .Include(x => x.Deparment)
                        .Include(x => x.Category)
                        .Include(course => course.CourseSections.Where(x => !x.IsDeleted))
                            .ThenInclude(cs => cs.Lessons.Where(x => !x.IsDeleted))
                                .ThenInclude(x => x.Quizzes.Where(x => !x.IsDeleted))
                                    .ThenInclude(q => q.Questions.Where(x => !x.IsDeleted)
                                ).Include(x => x.CourseSections.Where(x => !x.IsDeleted))
                                .ThenInclude(x => x.Lessons.Where(x => !x.IsDeleted))
                                    .ThenInclude(x => x.Practices)))
                     ?? throw new InvalidOperationException("Không tìm thấy Course với id " + request.Id);
            }
        }
    }
}
