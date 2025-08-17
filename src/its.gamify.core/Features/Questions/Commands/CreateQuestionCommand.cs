using its.gamify.core;
using its.gamify.core.Models.Questions;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.core.Features.Questions.Commands
{
    public class CreateQuestionCommand : IRequest<List<Question>>
    {
        public List<QuestionUpdateModel> Models { get; set; } = [];

        class CommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateQuestionCommand, List<Question>>
        {
            private async Task<Quiz> GetQuiz(int totalMark, int totalQuestions, double duration)
            {
                var quiz = new Quiz()
                {
                    TotalMark = totalMark,
                    Duration = duration,
                    PassedMark = totalMark / 2,
                    TotalQuestions = totalQuestions
                };
                await unitOfWork.QuizRepository.AddAsync(quiz);
                await unitOfWork.SaveChangesAsync();
                return quiz;
            }

            public async Task<List<Question>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
            {
                var questions = unitOfWork.Mapper.Map<List<Question>>(request.Models);
                var quiz = await GetQuiz(10, request.Models.Count, 100);
                foreach (var question in questions)
                {
                    question.QuizId = quiz.Id;
                }
                await unitOfWork.QuestionRepository.AddRangeAsync(questions, cancellationToken);
                await unitOfWork.SaveChangesAsync();
                return questions;
            }
        }
    }
}
