using its.gamify.api.Features.Lessons.Commands;
using its.gamify.core;
using MediatR;

namespace its.gamify.api.Features.CourseSections.Commands
{
    public class DeleteCourseSectionByIdCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        class CommandHandler(IUnitOfWork unitOfWork,
            IMediator mediator) : IRequestHandler<DeleteCourseSectionByIdCommand, bool>
        {

            public async Task<bool> Handle(DeleteCourseSectionByIdCommand request, CancellationToken cancellationToken)
            {
                var courseSection = await unitOfWork.CourseSectionRepository.GetByIdAsync(request.Id)
                    ?? throw new InvalidOperationException($"Không tìm thấy module");
                unitOfWork.CourseSectionRepository.SoftRemove(courseSection);

                var other_sections = await unitOfWork
                    .CourseSectionRepository
                    .WhereAsync(x =>
                        x.CourseId == courseSection.CourseId &&
                        x.Id != courseSection.Id &&
                        x.OrderedNumber > courseSection.OrderedNumber);

                if (other_sections.Count > 0)
                {
                    foreach (var section in other_sections)
                    {
                        section.OrderedNumber -= 1;
                    }

                    unitOfWork.CourseSectionRepository.UpdateRange(other_sections);
                }

                if (courseSection is not null)
                {
                    courseSection.IsDeleted = true;
                }
                foreach (var lesson in courseSection?.Lessons ?? [])
                {
                    await mediator.Send(new DeleteLessonCommand()
                    {
                        Id = lesson.Id
                    }, cancellationToken);
                }

                return await unitOfWork.SaveChangesAsync();
            }


        }
    }
}
