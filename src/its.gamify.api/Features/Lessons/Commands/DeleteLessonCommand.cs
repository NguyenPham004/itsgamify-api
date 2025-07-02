using its.gamify.api.Features.Practices.Commands;
using its.gamify.api.Features.Quizes.Commands;
using its.gamify.core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace its.gamify.api.Features.Lessons.Commands
{
    public class DeleteLessonCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        class CommandHandler : IRequestHandler<DeleteLessonCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IMediator mediator;
            public CommandHandler(IUnitOfWork unitOfWork,
                IMediator mediator)
            {
                this.mediator = mediator;
                this.unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
            {
                var lesson = await unitOfWork.LessonRepository.FirstOrDefaultAsync(x => x.Id == request.Id, includeFunc: x => x.Include(q => q.Quizzes));
                if (lesson != null)
                {
                    unitOfWork.LessonRepository.SoftRemove(lesson);
                    if (lesson.Quizzes?.Count > 0)
                    {
                        foreach (var item in lesson.Quizzes)
                        {
                            await mediator.Send(new DeleteQuizCommand()
                            {
                                Id = item.Id,
                            });
                        }
                    }
                    if (lesson.Practices?.Count > 0)
                    {
                        foreach (var item in lesson.Practices)
                        {
                            await mediator.Send(new DeletePracticeCommand()
                            {
                                Id = item.Id,
                            });
                        }
                    }
                    return true;
                }
                else throw new InvalidOperationException($"Không tìm thấy lesson với Id: {request.Id}");
            }
        }
    }
}
