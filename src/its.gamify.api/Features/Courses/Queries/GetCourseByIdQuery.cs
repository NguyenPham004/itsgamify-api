using its.gamify.core;
using its.gamify.domains.Entities;
using MediatR;

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
                    [x => x.CourseSections, x => x.Quarter, x => x.Category, x => x.LearningMaterials]))
                     ?? throw new InvalidOperationException("Không tìm thấy Course với id " + request.Id);
            }
        }
    }
}
