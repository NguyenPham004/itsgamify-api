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
                var res = new List<Question>();
                var isUpdate = request.QuestionUpsertModels.Any(x => x.CreateId is not null);
                Quiz? quiz = null;
                if (isUpdate)
                {
                    var question = await unitOfWork.QuestionRepository.GetByIdAsync(request.QuestionUpsertModels.FirstOrDefault(x => x.CreateId != Guid.Empty)!.CreateId ?? Guid.Empty);
                    quiz = await unitOfWork.QuizRepository.GetByIdAsync(question!.QuizId);

                }
                else
                {
                    quiz = await unitOfWork.QuizRepository.FirstOrDefaultAsync(x => x.LessonId == request
                        .LessonId);
                    if (quiz is null)
                    {
                        quiz = await GetQuiz(request.LessonId,
                request.QuestionUpsertModels.Count / 2, request.QuestionUpsertModels.Count);
                    }

                }

                foreach (var question in request.QuestionUpsertModels)
                {
                    bool isUpdateQuestion = question.CreateId != null;
                    Question? current = null;
                    if (isUpdate)
                    {
                        current = await unitOfWork.QuestionRepository.GetByIdAsync(question.CreateId ?? Guid.Empty);
                        unitOfWork.Mapper.Map(question, current);
                        unitOfWork.QuestionRepository.Update(current ?? throw new Exception("Mapping Question trong quiz"));
                    }
                    else
                    {
                        current = unitOfWork.Mapper.Map<Question>(question);
                        current.QuizId = quiz!.Id;
                        await unitOfWork.QuestionRepository.AddAsync(current ?? throw new InvalidOperationException("Có lỗi xảy ra khi mapping question"));
                    }
                    current.Quiz = quiz!;
                    await unitOfWork.SaveChangesAsync();
                    res.Add(current);






                }
                return res;
            }

        }
    }
}
