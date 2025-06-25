using its.gamify.core;
using its.gamify.core.Models.Courses;
using MediatR;

namespace its.gamify.api.Features.Courses.Queries
{
    public class GetCourseByIdQuery : IRequest<CourseViewModel>
    {
        public Guid Id { get; set; }
        class QueryHandler : IRequestHandler<GetCourseByIdQuery, CourseViewModel>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<CourseViewModel> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
            {
                return unitOfWork.Mapper.Map<CourseViewModel>(await unitOfWork.CourseRepository.GetByIdAsync(request.Id));
            }
        }
    }
}
