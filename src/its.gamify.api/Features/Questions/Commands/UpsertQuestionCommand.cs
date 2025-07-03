using its.gamify.core;
using its.gamify.core.Models.Questions;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Questions.Commands
{
    public class UpsertQuestionCommand : IRequest<List<Question>>
    {
        public Guid LessonId { get; set; } = Guid.Empty;
        public List<QuestionUpsertModel> QuestionUpsertModels { get; set; } = [];
        class CommandHandler : IRequestHandler<UpsertQuestionCommand, List<Question>>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            private async Task<Quiz> GetQuiz(Guid lessonId, int passMarks,
                int totalQuestions)
            {
                var quiz = new Quiz()
                {
                    LessonId = lessonId,
                    PassedMarks = passMarks,
                    TotalQuestions = totalQuestions
                };
                await unitOfWork.QuizRepository.AddAsync(quiz);
                await unitOfWork.SaveChangesAsync();
                return quiz;
            }
            public async Task<List<Question>> Handle(UpsertQuestionCommand request, CancellationToken cancellationToken)
            {

                Quiz? quiz = await unitOfWork.QuizRepository.FirstOrDefaultAsync(x => x.LessonId == request.LessonId);

                if (quiz != null)
                {
                    var tmp = await unitOfWork.QuestionRepository.WhereAsync(x => x.QuizId == quiz.Id);
                    if (tmp.Count > 0)
                    {
                        unitOfWork.QuestionRepository.SoftRemoveRange(tmp);
                        await unitOfWork.SaveChangesAsync();

                    }
                }

                quiz ??= await GetQuiz(request.LessonId, 10, request.QuestionUpsertModels.Count);
                var questions = unitOfWork.Mapper.Map<List<Question>>(request.QuestionUpsertModels);

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
