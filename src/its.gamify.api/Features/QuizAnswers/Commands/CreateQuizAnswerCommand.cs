using FluentValidation;
using its.gamify.api.Features.Questions.Commands;
using its.gamify.core;
using its.gamify.core.Models.Questions;
using its.gamify.core.Models.QuizAnswers;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.QuizAnswers.Commands
{
    public class CreateQuizAnswerCommand : QuizAnswerCreateModel, IRequest<QuizAnswer>
    {
        public QuizAnswerViewModel Model { get; set; } = new();
        class CommandValidation : AbstractValidator<QuizAnswerViewModel>
        {
            public CommandValidation()
            {
                RuleFor(x => x.Answer).NotEmpty().NotNull().WithMessage("Answer can not null.");
            }
        }
        class CommandHandler : IRequestHandler<CreateQuizAnswerCommand, QuizAnswer>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;

            }
            public async Task<QuizAnswer> Handle(CreateQuizAnswerCommand request, CancellationToken cancellationToken)
            {
                var quizAnswer = unitOfWork.Mapper.Map<QuizAnswer>(request);
                await unitOfWork.QuestionRepository.EnsureExistsIfIdNotEmpty(request.Model.QuestionId);
                await unitOfWork.QuizAnswerRepository.AddAsync(quizAnswer);
                await unitOfWork.SaveChangesAsync();
                return quizAnswer;
            }
        }
    }
}
