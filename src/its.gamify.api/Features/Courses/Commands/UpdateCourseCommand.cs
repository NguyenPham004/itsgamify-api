using FluentValidation;
using its.gamify.api.Features.CourseSections.Commands;
using its.gamify.api.Features.LearningMaterials.Commands;
using its.gamify.core;
using its.gamify.core.Models.Courses;
using its.gamify.domains.Enums;
using MediatR;

namespace its.gamify.api.Features.Courses.Commands
{
    public class UpdateCourseCommand : IRequest<bool>
    {

        public CourseUpdateModel Model { get; set; } = new();
        class CommandValidate : AbstractValidator<UpdateCourseCommand>
        {
            public CommandValidate()
            {
                RuleFor(x => x.Model.Title).NotEmpty().NotNull().WithMessage("Input title's course");
                //RuleFor(x => x.Model.DurationInHours).GreaterThanOrEqualTo(0).WithMessage("Duration in hour of course must be larger than 0");
            }
        }
        class CommandHandler : IRequestHandler<UpdateCourseCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMediator mediator;
            public CommandHandler(IUnitOfWork unitOfWork,
                IMediator mediator)
            {
                this.mediator = mediator;
                this.unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
            {
                var course = await unitOfWork.CourseRepository.FirstOrDefaultAsync(x => x.Id == request.Model.Id)
                    ?? throw new InvalidOperationException("Không tìm thấy course với Id " + request.Model.Id);
                if (request.Model.CourseSectionCreate?.Count > 0
                    && course.Status == CourseStatusEnum.Initial.ToString())
                {
                    course.Status = CourseStatusEnum.BaseContent.ToString();
                }
                unitOfWork.Mapper.Map(request.Model, course);

                foreach (var courseSection in request.Model.CourseSectionCreate ?? [])
                {
                    await mediator.Send(new UpsertCourseSectionCommand()
                    {
                        CourseId = request.Model.Id,
                        CreateId = courseSection.CreateId,
                        Description = courseSection.Description,
                        Lessons = courseSection.Lessons,
                        Title = courseSection.Title,
                    });
                }
                if (request.Model.LearningMaterialIds?.Count > 0)
                {
                    var learningMate = await mediator.Send(new UpsertLearningMaterials()
                    {
                        CourseId = request.Model.Id,
                        FileIds = request.Model.LearningMaterialIds,
                    });
                    course.Status = CourseStatusEnum.Material.ToString();

                    unitOfWork.CourseRepository.Update(course);
                    await unitOfWork.SaveChangesAsync();
                }
                if (request.Model.Status == CourseStatusEnum.Published.ToString())
                {
                    var courseToCheck = await unitOfWork.CourseRepository.GetByIdAsync(request.Model.Id, false, default,
                        [x => x.CourseSections, x => x.LearningMaterials]);
                    if (courseToCheck.CourseSections?.Count == 0) throw new InvalidOperationException("Chưa add bất kỳ module nào vào course");
                }
                await unitOfWork.SaveChangesAsync();

                return true;


            }
        }
    }
}
