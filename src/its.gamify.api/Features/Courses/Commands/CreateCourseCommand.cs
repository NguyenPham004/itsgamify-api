using FluentValidation;
using its.gamify.api.Features.CourseSections.Commands;
using its.gamify.core;
using its.gamify.core.IntegrationServices.Interfaces;
using its.gamify.core.Models.Courses;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
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
                RuleFor(x => x.DepartmentId).NotNull().NotEmpty();


            }
        }
        class CommandHandler : IRequestHandler<CreateCourseCommand, Course>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IFirebaseService firebaseService;
            private readonly IMediator mediator;
            public CommandHandler(IUnitOfWork unitOfWork,
                IFirebaseService firebaseService,
                IMediator mediator)
            {
                this.mediator = mediator;
                this.firebaseService = firebaseService;
                this.unitOfWork = unitOfWork;

            }
            private async Task<Quarter> UpsertQuarter(DateTime datetime)
            {
                var quater = await unitOfWork.QuarterRepository.FirstOrDefaultAsync(x => x.StartDate >= datetime && datetime <= x.EndDate);
                if (quater is null)
                {
                    // Create new 
                    quater = new Quarter()
                    {
                        Name = $"Quý {(int)(datetime.Month / 4) + 1} {datetime.Year}",
                        StartDate = datetime,
                        EndDate = datetime.AddMonths(3),
                    };
                    unitOfWork.QuarterRepository.AddAsync(quater);
                    await unitOfWork.SaveChangesAsync();
                }
                return quater;
            }
            public async Task<Course> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
            {
                var course = unitOfWork.Mapper.Map<Course>((CourseCreateModel)request);
                if (request.CourseSectionCreate?.Count > 0)
                {
                    course.Status = CourseStatusEnum.Material.ToString();

                }

                course.ThumbnailImage = (await unitOfWork.FileRepository.FirstOrDefaultAsync(x => x.Id == request.ThumbNailImageId) ?? throw new InvalidOperationException("Không tìm thấy image thumbnail")).Url;
                course.IntroVideo = (await unitOfWork.FileRepository.FirstOrDefaultAsync(x => x.Id == request.IntroductionVideoId) ?? throw new InvalidOperationException("Không tìm thấấy Intro Video với Id " + request.IntroductionVideoId)).Url;
                course.ThumbnailId = request.ThumbNailImageId;
                course.IntroVideoId = request.IntroductionVideoId;
                var quarter = await UpsertQuarter(DateTime.Now);
                course.QuarterId = quarter.Id;
                await unitOfWork.CourseRepository.AddAsync(course);
                await unitOfWork.SaveChangesAsync();
                if (request.CourseSectionCreate?.Count > 0)
                {
                    for (int i = 0; i < request.CourseSectionCreate.Count; i++)
                    {
                        var section = request.CourseSectionCreate[i];

                        var courseSection = await mediator.Send(new UpsertCourseSectionCommand()
                        {
                            CourseId = course.Id,
                            Description = section.Description,
                            Lessons = section.Lessons,
                            Title = section.Title,
                        });

                    }
                }
                return course;
            }
        }
    }
}
