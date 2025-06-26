using its.gamify.api.Features.Questions.Commands;
using its.gamify.core;
using MediatR;

namespace its.gamify.api.Features.QuizResults.Commands
{
    public class DeleteQuizResultCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        class CommandHandler : IRequestHandler<DeleteQuizResultCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(DeleteQuizResultCommand request, CancellationToken cancellationToken)
            {
                var quizResult = await unitOfWork.QuizResultRepository.GetByIdAsync(request.Id);
                if (quizResult is not null)
                {
                    unitOfWork.QuizResultRepository.SoftRemove(quizResult);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new InvalidOperationException("Quiz result not found");
            }
        }

    }
}
