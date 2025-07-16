using its.gamify.api.Features.Users.Commands;
using its.gamify.core;
using its.gamify.core.GlobalExceptionHandling.Exceptions;
using MediatR;

namespace its.gamify.api.Features.Courses.Commands
{
    public class DeleteCourseCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        class CommandHandler : IRequestHandler<DeleteCourseCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
            {
                var course = await unitOfWork.CourseRepository.GetByIdAsync(request.Id)
                    ?? throw new BadRequestException("Khóa học không tồn tại!");

                unitOfWork.CourseRepository.SoftRemove(course);
                return await unitOfWork.SaveChangesAsync();


            }
        }

    }
}
