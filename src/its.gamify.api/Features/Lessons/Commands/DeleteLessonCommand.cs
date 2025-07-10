using its.gamify.api.Features.Practices.Commands;
using its.gamify.api.Features.Quizes.Commands;
using its.gamify.core;
using its.gamify.domains.Enums;
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
            public CommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
            {
                this.mediator = mediator;
                this.unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
            {
                var lesson = await unitOfWork.LessonRepository.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (lesson != null)
                {
                    unitOfWork.LessonRepository.SoftRemove(lesson);
                    await unitOfWork.SaveChangesAsync();
                    if (lesson.Type == LearningMaterialType.QUIZ.ToString())
                    {
                        var quiz = await unitOfWork.QuizRepository.GetByIdAsync(lesson.QuizId!.Value)
                            ?? throw new Exception("Can not finding quiz");
                        var tmp = await unitOfWork.QuestionRepository.WhereAsync(x => x.QuizId == quiz.Id);

                        if (tmp.Count > 0)
                        {
                            unitOfWork.QuestionRepository.SoftRemoveRange(tmp);
                            await unitOfWork.SaveChangesAsync();

                        }
                    }
                    return true;
                }
                else throw new InvalidOperationException($"Không tìm thấy lesson với Id: {request.Id}");
            }
        }
    }
}
