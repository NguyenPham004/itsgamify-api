using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models;
using its.gamify.core.Models.Courses;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.Courses.Commands
{
    public class ReActiveCourseCommand : BaseReActiveModel, IRequest<Course>
    {
        public Guid Id { get; set; }
        class CommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<ReActiveCourseCommand, Course>
        {
            public async Task<Course> Handle(ReActiveCourseCommand request, CancellationToken cancellationToken)
            {
                var course = await unitOfWork.CourseRepository.GetByIdAsync(request.Id, true) ?? throw new NotFoundException("Không tìm thấy khóa học.");
                course.IsDeleted = request.IsActive;
                unitOfWork.CourseRepository.Update(course);
                await unitOfWork.SaveChangesAsync();
                return course;
            }
        }
    }
}
