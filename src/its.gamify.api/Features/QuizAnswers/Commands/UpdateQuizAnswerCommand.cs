using FluentValidation;
using its.gamify.api.Features.Questions.Commands;
using its.gamify.core;
using its.gamify.core.Models.Questions;
using its.gamify.core.Models.QuizAnswers;
using MediatR;

namespace its.gamify.api.Features.QuizAnswers.Commands
{
    public class UpdateQuizAnswerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public QuizAnswerViewModel Model { get; set; } = new();
        class CommandValidate : AbstractValidator<UpdateQuizAnswerCommand>
        {
            public CommandValidate()
            {
                RuleFor(x => x.Model.Answer).NotEmpty().NotNull().WithMessage("Answer not null or empty");
            }
        }
        class CommandHandler : IRequestHandler<UpdateQuizAnswerCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(UpdateQuizAnswerCommand request, CancellationToken cancellationToken)
            {
                await unitOfWork.QuestionRepository.EnsureExistsIfIdNotEmpty(request.Model.QuestionId);
                var quizAnswer = await unitOfWork.QuizAnswerRepository.GetByIdAsync(request.Id);
                if (quizAnswer is not null)
                {
                    unitOfWork.Mapper.Map(request.Model, quizAnswer);
                    unitOfWork.QuizAnswerRepository.Update(quizAnswer);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new InvalidOperationException("Quiz answer not found");

            }
        }
    }
}
