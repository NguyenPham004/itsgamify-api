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
                var item = DateTimeUtilities.GetQuarterDates(datetime.Year, datetime.Month);
                if (quater is null)
                {
                    // Create new 
                    quater = new Quarter()
                    {
                        Name = $"Quý {(int)(datetime.Month / 4) + 1} {datetime.Year}",
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        Year = datetime.Year
                    };
                    await unitOfWork.QuarterRepository.AddAsync(quater);
                    await unitOfWork.SaveChangesAsync();
                }
                return quater;
            }
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
                var quarter = await UpsertQuarter(DateTime.Now);
                course.QuarterId = quarter.Id;
                await unitOfWork.CourseRepository.AddAsync(course, cancellationToken);
                await unitOfWork.SaveChangesAsync();
                return course;
            }
        }
    }
}
