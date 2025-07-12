using FluentValidation;
using its.gamify.core;
using its.gamify.core.Models.QuizAnswers;
using its.gamify.core.Models.QuizResults;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using MediatR;

namespace its.gamify.api.Features.QuizResults.Commands
{
    public class CreateQuizResultCommand : IRequest<QuizResult>
    {
        public QuizResultCreateModel Model { get; set; } = new();
        class CommandValidation : AbstractValidator<QuizResultViewModel>
        {
            public CommandValidation()
            {
                RuleFor(x => x.QuizId).NotEmpty().WithMessage("Quiz ID is required");
                RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required");
                RuleForEach(x => x.Answers).SetValidator(new QuizAnswerValidator());
            }
        }

        public class QuizAnswerValidator : AbstractValidator<QuizAnswerCreateModel>
        {
            public QuizAnswerValidator()
            {
                RuleFor(x => x.QuestionId).NotEmpty().WithMessage("Question ID is required");
                RuleFor(x => x.Answer).Null();
            }
        }
        class CommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateQuizResultCommand, QuizResult>
        {
            public async Task<QuizResult> Handle(CreateQuizResultCommand request, CancellationToken cancellationToken)
            {
                var quiz = await _unitOfWork.QuizRepository
                    .GetByIdAsync(request.Model.QuizId, includes: x => x.Questions.Where(x => !x.IsDeleted))
                    ?? throw new Exception("Invalid quiz id");

                var answers = request.Model.Answers;

                // Tạo và tính toán kết quả bài kiểm tra
                var quizResult = TrackQuizResult(quiz, answers);

                // Lưu kết quả vào database
                await _unitOfWork.QuizResultRepository.AddAsync(quizResult, cancellationToken);
                if (request.Model.Type == QUIZ_RESULT_TYPE.LESSON)
                {
                    var progress = await _unitOfWork
                        .LearningProgressRepository
                        .FirstOrDefaultAsync(x => x.CourseParticipationId == request.Model.ParticipationId && x.LessonId == request.Model.TypeId);

                    if (progress == null)
                    {
                        await _unitOfWork.LearningProgressRepository.AddAsync(new LearningProgress
                        {
                            Status = PROGRESS_STATUS.COMPLETED,
                            CourseParticipationId = request.Model.ParticipationId,
                            LessonId = request.Model.TypeId,
                            QuizResultId = quizResult.Id
                        }, cancellationToken);
                    }
                }

                await _unitOfWork.SaveChangesAsync();
                return quizResult;
            }

            private static QuizResult TrackQuizResult(Quiz quiz, IEnumerable<QuizAnswerCreateModel> userAnswers)
            {
                // Tạo đối tượng QuizResult mới
                var quizResult = new QuizResult
                {
                    CompletedDate = DateTime.UtcNow,
                    QuizAnswers = []
                };

                double totalScore = 0;
                double markPerQuestion = quiz.TotalQuestions > 0 ? quiz.TotalMark / quiz.TotalQuestions : 0;
                var questionDict = quiz.Questions.ToDictionary(q => q.Id);

                // Xử lý từng câu trả lời của người dùng
                foreach (var userAnswer in userAnswers)
                {
                    // Kiểm tra xem câu hỏi có tồn tại trong quiz không
                    if (questionDict.TryGetValue(userAnswer.QuestionId, out var question))
                    {
                        // Tạo đối tượng QuizAnswer
                        var quizAnswer = new QuizAnswer
                        {
                            QuestionId = userAnswer.QuestionId,
                            Answer = userAnswer.Answer!,
                            IsCorrect = false,
                            QuizResultId = quizResult.Id
                        };

                        // Kiểm tra câu trả lời có đúng không bằng cách so sánh với CorrectAnswer
                        if (question.CorrectAnswer.Equals(userAnswer.Answer, StringComparison.OrdinalIgnoreCase))
                        {
                            quizAnswer.IsCorrect = true;
                            totalScore += markPerQuestion; // Cộng điểm nếu câu trả lời đúng
                        }

                        // Thêm câu trả lời vào danh sách
                        quizResult.QuizAnswers.Add(quizAnswer);
                    }
                }

                // Cập nhật điểm số và trạng thái đỗ/trượt
                quizResult.Score = totalScore;
                quizResult.IsPassed = totalScore >= quiz.PassedMark;

                return quizResult;
            }
        }
    }
}
