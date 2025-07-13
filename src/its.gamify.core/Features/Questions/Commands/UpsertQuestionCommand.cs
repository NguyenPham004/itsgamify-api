using its.gamify.core;
using its.gamify.core.Models.Questions;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Questions.Commands
{
    public class UpsertQuestionCommand : IRequest<Guid>
    {
        public Guid QuizId { get; set; } = Guid.Empty;
        public List<QuestionUpsertModel> QuestionUpsertModels { get; set; } = [];
        public double Duration { get; set; }
        class CommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpsertQuestionCommand, Guid>
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
                await _unitOfWork.QuizRepository.AddAsync(quiz);
                await _unitOfWork.SaveChangesAsync();
                return quiz;
            }
            public async Task<Guid> Handle(UpsertQuestionCommand request, CancellationToken cancellationToken)
            {

                Quiz? quiz = await _unitOfWork.QuizRepository.GetByIdAsync(request.QuizId);

                if (quiz != null)
                {
                    quiz.TotalQuestions = request.QuestionUpsertModels.Count;
                    quiz.Duration = request.Duration;
                    _unitOfWork.QuizRepository.Update(quiz);

                    var tmp = await _unitOfWork.QuestionRepository.WhereAsync(x => x.QuizId == quiz.Id);
                    if (tmp.Count > 0)
                    {
                        _unitOfWork.QuestionRepository.SoftRemoveRange(tmp);
                        await _unitOfWork.SaveChangesAsync();

                    }
                }

                quiz ??= await GetQuiz(10, request.QuestionUpsertModels.Count, request.Duration);
                var questions = _unitOfWork.Mapper.Map<List<Question>>(request.QuestionUpsertModels);

                foreach (var question in questions)
                {
                    question.QuizId = quiz.Id;
                }

                await _unitOfWork.QuestionRepository.AddRangeAsync(questions, cancellationToken);
                await _unitOfWork.SaveChangesAsync();

                return quiz.Id;
            }

        }
    }
}
