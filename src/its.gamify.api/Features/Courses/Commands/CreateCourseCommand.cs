using FluentValidation;
using its.gamify.core;
using its.gamify.core.IntegrationServices.Interfaces;
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
                RuleFor(x => x.DifficultyLevelId).NotNull().NotEmpty();
                RuleFor(x => x.QuarterId).NotNull().NotEmpty();

            }
        }
        class CommandHandler : IRequestHandler<CreateCourseCommand, Course>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IFirebaseService firebaseService;
            public CommandHandler(IUnitOfWork unitOfWork,
                IFirebaseService firebaseService)
            {
                this.firebaseService = firebaseService;
                this.unitOfWork = unitOfWork;

            }
            public async Task<Course> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
            {
                var course = unitOfWork.Mapper.Map<Course>(request);
                if (request.ThumbNail is not null)
                {
                    var fileRes = await firebaseService.UploadFileAsync(request.ThumbNail.File,
                        request.ThumbNail.Directory ?? string.Empty);
                    if (fileRes.fileName != string.Empty)
                    {
                        course.Medias.Add($"ThumbNail|{fileRes.fileName}|{fileRes.url}");
                    }
                }
                if (request.IntroVideo is not null)
                {
                    var fileRes = await firebaseService.UploadFileAsync(request.IntroVideo.File,
                       request.IntroVideo.Directory ?? string.Empty);
                    if (fileRes.fileName != string.Empty)
                    {
                        course.Medias.Add($"Video|{fileRes.fileName}|{fileRes.url}");
                    }
                }

                await unitOfWork.CourseRepository.AddAsync(course);
                await unitOfWork.SaveChangesAsync();
                return course;
            }
        }
    }
}
