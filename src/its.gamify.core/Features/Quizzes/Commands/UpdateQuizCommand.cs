using FluentValidation;
using its.gamify.api.Features.Questions.Commands;
using its.gamify.core;
using its.gamify.core.Models.Questions;
using its.gamify.core.Models.Quizes;
using MediatR;

namespace its.gamify.api.Features.Quizzes.Commands
{
    public class UpdateQuizCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public QuizUpdateModel Model { get; set; } = new();
        class CommandValidate : AbstractValidator<UpdateQuizCommand>
        {
            public CommandValidate()
            {
                RuleFor(x => x.Model.TotalMark).GreaterThanOrEqualTo(0).WithMessage("Total mark must be larger than or equal 0");
                RuleFor(x => x.Model.PassedMark).GreaterThanOrEqualTo(0).WithMessage("Passed mark must be larger than or equal 0");
                RuleFor(x => x.Model.TotalQuestion).GreaterThan(0).WithMessage("Total question must be larger than 0");
            }
        }
        class CommandHandler : IRequestHandler<UpdateQuizCommand, bool>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
            {
                await unitOfWork.LessonRepository.EnsureExistsIfIdNotEmpty(request.Model.LessonId);
                await unitOfWork.ChallengeRepository.EnsureExistsIfIdNotEmpty(request.Model.ChallengIdId);
                var quiz = await unitOfWork.QuizRepository.GetByIdAsync(request.Id);
                if (quiz is not null)
                {
                    unitOfWork.Mapper.Map(request.Model, quiz);
                    unitOfWork.QuizRepository.Update(quiz);
                    return await unitOfWork.SaveChangesAsync();
                }
                else throw new InvalidOperationException("Quiz not found");

            }
        }
    }
}
