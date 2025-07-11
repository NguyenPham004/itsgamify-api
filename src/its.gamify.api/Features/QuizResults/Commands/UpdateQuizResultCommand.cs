using FluentValidation;
using its.gamify.api.Features.Questions.Commands;
using its.gamify.core;
using its.gamify.core.Models.Questions;
using its.gamify.core.Models.QuizResults;
using MediatR;

namespace its.gamify.api.Features.QuizResults.Commands
{
    public class UpdateQuizResultCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public QuizResultUpdateModel Model { get; set; } = new();
        class CommandValidate : AbstractValidator<UpdateQuizResultCommand>
        {
            public CommandValidate()
            {
                // RuleFor(x => x.Model.Score).GreaterThanOrEqualTo(0).WithMessage("Score must be larger or equal than 0");
            }
        }
        class CommandHandler : IRequestHandler<UpdateQuizResultCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(UpdateQuizResultCommand request, CancellationToken cancellationToken)
            {
                var quizResult = await unitOfWork.QuizResultRepository.GetByIdAsync(request.Id);
                if (quizResult is not null)
                {
                    unitOfWork.Mapper.Map(request.Model, quizResult);
                    unitOfWork.QuizResultRepository.Update(quizResult);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new InvalidOperationException("Quiz result not found");

            }
        }
    }
}
