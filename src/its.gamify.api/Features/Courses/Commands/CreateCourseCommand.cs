using FluentValidation;
using its.gamify.api.Features.Users.Commands;
using its.gamify.core;
using its.gamify.core.Models.Courses;
using its.gamify.core.Models.Users;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Courses.Commands
{
    public class CreateCourseCommand : IRequest<CourseViewModel?>
    {
        public CourseViewModel Model { get; set; } = new();
        class CommandValidation : AbstractValidator<CreateCourseCommand>
        {
            public CommandValidation()
            {
                RuleFor(x => x.Model.Title).NotEmpty().NotNull().WithMessage("Input title's course");
                RuleFor(x => x.Model.DurationInHours).GreaterThanOrEqualTo(0).WithMessage("Duration in hour of course must be larger than 0");
            }
        }
        class CommandHandler : IRequestHandler<CreateCourseCommand, CourseViewModel?>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IAuthService authService;
            public CommandHandler(IUnitOfWork unitOfWork,
                IAuthService authService)
            {
                this.authService = authService;
                this.unitOfWork = unitOfWork;

            }
            public async Task<CourseViewModel?> Handle(CreateCourseCommand request,
                CancellationToken cancellationToken)
            {
                var course = unitOfWork.Mapper.Map<Course>(request.Model);
                await unitOfWork.CourseRepository.AddAsync(course);
                if (await unitOfWork.SaveChangesAsync())
                {
                    return unitOfWork.Mapper.Map<CourseViewModel>(await unitOfWork.CourseRepository.GetByIdAsync(course.Id,
                        false, cancellationToken, x => x.QuarterId!));
                }
                else return null;
            }
        }
    }
}
