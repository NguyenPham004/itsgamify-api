using its.gamify.api.Features.Questions.Commands;
using its.gamify.core;
using MediatR;

namespace its.gamify.api.Features.QuizAnswers.Commands
{
    public class DeleteQuizAnswerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        class CommandHandler : IRequestHandler<DeleteQuizAnswerCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(DeleteQuizAnswerCommand request, CancellationToken cancellationToken)
            {
                var quizAnswer = await unitOfWork.QuizAnswerRepository.GetByIdAsync(request.Id);
                if (quizAnswer is not null)
                {
                    unitOfWork.QuizAnswerRepository.SoftRemove(quizAnswer);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new InvalidOperationException("Quiz answer not found");
            }
        }

    }
}
