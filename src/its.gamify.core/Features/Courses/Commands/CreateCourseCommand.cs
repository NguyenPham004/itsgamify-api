using FluentValidation;
using its.gamify.api.Features.CourseSections.Commands;
using its.gamify.core;
using its.gamify.core.IntegrationServices.Interfaces;
using its.gamify.core.Models.Courses;
using its.gamify.core.Utilities;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using MediatR;

namespace its.gamify.api.Features.Courses.Commands
{
    public class CreateCourseCommand : CourseCreateModels, IRequest<Course>
    {

        class CommandValidation : AbstractValidator<CreateCourseCommand>
        {
            public CommandValidation()
            {
                RuleFor(x => x.CategoryId).NotNull().NotEmpty().WithMessage("Vui lòng nhập category id");
            }
        }
        class CommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCourseCommand, Course>
        {

            public async Task<Course> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
            {
                var course = unitOfWork.Mapper.Map<Course>(request);
                course.Status = CourseStatusEnum.INITIAL.ToString();
                course.ThumbnailImage = (await unitOfWork.FileRepository.FirstOrDefaultAsync(x => x.Id == request.ThumbnailId)
                    ?? throw new InvalidOperationException("Không tìm thấy image thumbnail")).Url;
                course.IntroVideo = (await unitOfWork.FileRepository.FirstOrDefaultAsync(x => x.Id == request.IntroVideoId)
                    ?? throw new InvalidOperationException("Không tìm thấy Intro Video với Id " + request.IntroVideoId)).Url;
                course.ThumbnailId = request.ThumbnailId;
                course.IntroVideoId = request.IntroVideoId;
                await unitOfWork.CourseRepository.AddAsync(course, cancellationToken);
                await unitOfWork.SaveChangesAsync();
                return course;
            }
        }
    }
}
