using FluentValidation;
using its.gamify.core;
using its.gamify.core.Models.Courses;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Courses.Commands
{
    public class CreateCourseCommand : CourseCreateModel, IRequest<Course>
    {
        class CommandValidation : AbstractValidator<CreateCourseCommand>
        {
            public CommandValidation()
            {
                RuleFor(x => x.CategoryId).NotNull().NotEmpty();
            }
        }
        class CommandHandler : IRequestHandler<CreateCourseCommand, Course>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;

            }
            public async Task<Course> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
            {
                var course = unitOfWork.Mapper.Map<Course>(request);
                await unitOfWork.CourseRepository.AddAsync(course);
                await unitOfWork.SaveChangesAsync();
                return course;
            }
        }
    }
}
