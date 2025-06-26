using FluentValidation;
using its.gamify.api.Features.Courses.Commands;
using its.gamify.core;
using its.gamify.core.Models.Courses;
using its.gamify.core.Models.Questions;
using MediatR;

namespace its.gamify.api.Features.Questions.Commands
{
    public class UpdateQuestionCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public QuestionUpdateModel Model { get; set; } = new();
        class CommandValidate : AbstractValidator<UpdateQuestionCommand>
        {
            public CommandValidate()
            {
                RuleFor(x => x.Model.Content).NotEmpty().NotNull().WithMessage("Content can not null.");
                RuleFor(x => x.Model.OptionA).NotEmpty().NotNull().WithMessage("Option A can not null.");
                RuleFor(x => x.Model.OptionB).NotEmpty().NotNull().WithMessage("Option B can not null.");
                RuleFor(x => x.Model.OptionC).NotEmpty().NotNull().WithMessage("Option C can not null.");
                RuleFor(x => x.Model.OptionD).NotEmpty().NotNull().WithMessage("Option D can not null.");
                RuleFor(x => x.Model.CorrectAnswer).NotEmpty().NotNull().WithMessage("Correct answer can not null.");
                RuleFor(x => x.Model.Explanation).NotEmpty().NotNull().WithMessage("Explanation can not null.");
                RuleFor(x => x.Model.QuizId).NotNull().WithMessage("Input Quiz belong to");
            }
        }
        class CommandHandler : IRequestHandler<UpdateQuestionCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
            {
                await unitOfWork.QuizRepository.EnsureExistsIfIdNotEmpty(request.Model.QuizId);
                var question = await unitOfWork.QuestionRepository.GetByIdAsync(request.Id);
                if (question is not null)
                {
                    unitOfWork.Mapper.Map(request.Model, question);
                    unitOfWork.QuestionRepository.Update(question);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new InvalidOperationException("Question not found");

            }
        }
    }
}
