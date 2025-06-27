using its.gamify.api.Features.Questions.Commands;
using its.gamify.core;
using MediatR;

namespace its.gamify.api.Features.Quizes.Commands
{
    public class DeleteQuizCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        class CommandHandler : IRequestHandler<DeleteQuizCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
            {
                var quiz = await unitOfWork.QuizRepository.GetByIdAsync(request.Id);
                if (quiz is not null)
                {
                    unitOfWork.QuizRepository.SoftRemove(quiz);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new InvalidOperationException("Quiz not found");
            }
        }
    }
}
