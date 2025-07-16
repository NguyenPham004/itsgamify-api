using its.gamify.api.Features.Courses.Commands;
using its.gamify.core;
using MediatR;

namespace its.gamify.api.Features.Questions.Commands
{
    public class DeleteQuestionCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        class CommandHandler : IRequestHandler<DeleteQuestionCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<bool> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
            {
                var question = await unitOfWork.QuestionRepository.GetByIdAsync(request.Id);
                if (question is not null)
                {
                    unitOfWork.QuestionRepository.SoftRemove(question);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new InvalidOperationException("Question not found");
            }
        }

    }
}
