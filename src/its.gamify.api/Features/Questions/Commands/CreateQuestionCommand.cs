using FluentValidation;
using its.gamify.core;
using its.gamify.core.Models.Questions;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Questions.Commands
{
    public class CreateQuestionCommand : QuestionCreateModel, IRequest<Question>
    {
        public QuestionViewModel Model { get; set; } = new();
        class CommandValidation : AbstractValidator<QuestionViewModel>
        {
            public CommandValidation()
            {
                RuleFor(x => x.Content).NotEmpty().NotNull().WithMessage("Content can not null.");
                RuleFor(x => x.OptionA).NotEmpty().NotNull().WithMessage("Option A can not null.");
                RuleFor(x => x.OptionB).NotEmpty().NotNull().WithMessage("Option B can not null.");
                RuleFor(x => x.OptionC).NotEmpty().NotNull().WithMessage("Option C can not null.");
                RuleFor(x => x.OptionD).NotEmpty().NotNull().WithMessage("Option D can not null.");
                RuleFor(x => x.CorrectAnswer).NotEmpty().NotNull().WithMessage("Correct answer can not null.");
                RuleFor(x => x.Explanation).NotEmpty().NotNull().WithMessage("Explanation can not null.");
                RuleFor(x => x.QuizId).NotNull().WithMessage("Input Quiz belong to");
            }
        }
        class CommandHandler : IRequestHandler<CreateQuestionCommand, Question>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;

            }
            public async Task<Question> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
            {
                var question = unitOfWork.Mapper.Map<Question>(request);
                await unitOfWork.QuizRepository.EnsureExistsIfIdNotEmpty(request.Model.QuizId);
                await unitOfWork.QuestionRepository.AddAsync(question);
                await unitOfWork.SaveChangesAsync();
                return question;
            }
        }
    }
}
