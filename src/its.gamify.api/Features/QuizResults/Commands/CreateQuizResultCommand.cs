using FluentValidation;
using its.gamify.api.Features.Questions.Commands;
using its.gamify.core;
using its.gamify.core.Models.Questions;
using its.gamify.core.Models.QuizResults;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.QuizResults.Commands
{
    public class CreateQuizResultCommand : QuizResultCreateModel, IRequest<QuizResult>
    {
        public QuizResultViewModel Model { get; set; } = new();
        class CommandValidation : AbstractValidator<QuizResultViewModel>
        {
            public CommandValidation()
            {
                RuleFor(x => x.Score).GreaterThanOrEqualTo(0).WithMessage("Score must be larger or equal than 0");

            }
        }
        class CommandHandler : IRequestHandler<CreateQuizResultCommand, QuizResult>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;

            }
            public async Task<QuizResult> Handle(CreateQuizResultCommand request, CancellationToken cancellationToken)
            {
                var quizResult = unitOfWork.Mapper.Map<QuizResult>(request);
                await unitOfWork.LessonRepository.EnsureExistsIfIdNotEmpty(request.Model.LearningProgressId);
                await unitOfWork.QuizResultRepository.AddAsync(quizResult);
                await unitOfWork.SaveChangesAsync();
                return quizResult;
            }
        }
    }
}
