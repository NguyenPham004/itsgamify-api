using its.gamify.core;
using its.gamify.core.IntegrationServices.Interfaces;
using its.gamify.core.Models.CourseSections;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.CourseSections.Commands
{
    public class CreateCourseSectionCommand : CourseSectionCreateModel, IRequest<CourseSection>
    {
        public Guid CourseId { get; set; }
        class CommandHandler : IRequestHandler<CreateCourseSectionCommand, CourseSection>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IFirebaseService firebaseSerivce;
            public CommandHandler(IUnitOfWork unitOfWork,
                IFirebaseService firebaseService)
            {
                this.firebaseSerivce = firebaseService;
                this.unitOfWork = unitOfWork;
            }
            public async Task<CourseSection> Handle(CreateCourseSectionCommand request, CancellationToken cancellationToken)
            {
                var courseSection = unitOfWork.Mapper.Map<CourseSection>(request);
                courseSection.CourseId = request.CourseId;
                var lessons = new List<Lesson>();
                foreach (var x in request.Lessons)
                {
                    var res = await firebaseSerivce.UploadFileAsync(x.File.File, x.File.Directory ?? string.Empty);
                    var lesson = new Lesson()
                    {
                        CourseSectionId = courseSection.Id,
                        Title = x.Title,
                        Type = x.Type,
                        Url = res.url,
                        DurationInMinutes = x.DurationInMinutes,
                        Description = x.Description
                    };
                    lessons.Add(lesson);
                }

                await unitOfWork.CourseSectionRepository.AddAsync(courseSection);
                await unitOfWork.SaveChangesAsync();
                await unitOfWork.LessonRepository.AddRangeAsync(lessons);
                await unitOfWork.SaveChangesAsync();
                courseSection.Lessons = lessons;
                return courseSection;

            }
        }
    }
}
