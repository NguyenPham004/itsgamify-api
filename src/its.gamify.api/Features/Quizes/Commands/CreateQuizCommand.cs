using FluentValidation;
using its.gamify.api.Features.Questions.Commands;
using its.gamify.core;
using its.gamify.core.Models.Questions;
using its.gamify.core.Models.Quizes;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Quizes.Commands
{
    public class CreateQuizCommand : QuizCreateModel, IRequest<Quiz>
    {
        public QuizViewModel Model { get; set; } = new();
        class CommandValidation : AbstractValidator<QuizViewModel>
        {
            public CommandValidation()
            {
                RuleFor(x=>x.TotalMarks).GreaterThanOrEqualTo(0).WithMessage("Total mark must be larger than or equal 0");
                RuleFor(x=>x.PassedMarks).GreaterThanOrEqualTo(0).WithMessage("Passed mark must be larger than or equal 0");
                RuleFor(x=>x.TotalQuestions).GreaterThan(0).WithMessage("Total question must be larger than 0");
            }
        }
        class CommandHandler : IRequestHandler<CreateQuizCommand, Quiz>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;

            }
            public async Task<Quiz> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
            {
                var quiz = unitOfWork.Mapper.Map<Quiz>(request);
                await unitOfWork.QuizRepository.AddAsync(quiz);
                await unitOfWork.SaveChangesAsync();
                return quiz;
            }
        }
    }
}
