using its.gamify.api.Features.Lessons.Commands;
using its.gamify.core;
using MediatR;

namespace its.gamify.api.Features.CourseSections.Commands
{
    public class DeleteCourseSectionByIdCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        class CommandHandler : IRequestHandler<DeleteCourseSectionByIdCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMediator mediato;
            public CommandHandler(IUnitOfWork unitOfWork,
                IMediator mediator)
            {
                this.mediato = mediator;
                this.unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(DeleteCourseSectionByIdCommand request, CancellationToken cancellationToken)
            {
                var courseSection = await unitOfWork.CourseSectionRepository.GetByIdAsync(request.Id)
                    ?? throw new InvalidOperationException($"Không tìm thấy module");
                unitOfWork.CourseSectionRepository.SoftRemove(courseSection);
                if (courseSection is not null)
                {
                    courseSection.IsDeleted = true;
                }
                foreach (var lesson in courseSection?.Lessons ?? [])
                {
                    await mediato.Send(new DeleteLessonCommand()
                    {
                        Id = lesson.Id
                    });
                }

                return await unitOfWork.SaveChangesAsync();
            }


        }
    }
}
