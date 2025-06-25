using FluentValidation;
using its.gamify.api.Features.Users.Commands;
using its.gamify.core;
using its.gamify.core.Models.Courses;
using its.gamify.core.Models.Users;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.WebSockets;

namespace its.gamify.api.Features.Courses.Commands
{
    public class UpdateCourseCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public CourseUpdateModel Model { get; set; } = new();
        class CommandValidate: AbstractValidator<UpdateCourseCommand>
        {
            public CommandValidate() {
                RuleFor(x=> x.Model.Title).NotEmpty().NotNull().WithMessage("Input title's course");
                RuleFor(x => x.Model.DurationInHours).GreaterThanOrEqualTo(0).WithMessage("Duration in hour of course must be larger than 0");
            }
        }
        class CommandHandler : IRequestHandler<UpdateCourseCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
            {
                await unitOfWork.QuarterRepository.EnsureExistsIfIdNotEmpty(request.Model.QuarterId);
                await unitOfWork.DifficultyRepository.EnsureExistsIfIdNotEmpty(request.Model.DifficultyLevelId);
                await unitOfWork.CategoryRepository.EnsureExistsIfIdNotEmpty(request.Model.CategoryId);
                if(request.Model.QuarterId != Guid.Empty)
                {
                    var find = await unitOfWork.QuarterRepository.GetByIdAsync(request.Model.QuarterId);
                    if (find == null) throw new ArgumentNullException("Quarter in " + request.Model.Title + " not found");
                }
                var quarter = await unitOfWork.QuarterRepository.GetByIdAsync(request.Model.QuarterId);
                var course = await unitOfWork.CourseRepository.GetByIdAsync(request.Id);
                if (course is not null)
                {
                    unitOfWork.Mapper.Map(request.Model, course);
                    unitOfWork.CourseRepository.Update(course);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new InvalidOperationException("Couse not found");

            }
        }
    }
}
