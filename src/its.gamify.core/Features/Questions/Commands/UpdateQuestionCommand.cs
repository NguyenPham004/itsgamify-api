using its.gamify.core.GlobalExceptionHandling.Exceptions;
using its.gamify.core.Models.Questions;
using MediatR;

namespace its.gamify.core.Features.Questions.Commands
{
    public class UpdateQuestionCommand : IRequest<bool>
    {
        public List<QuestionUpdateModel> Models { get; set; } = new();

        class CommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateQuestionCommand, bool>
        {

            public async Task<bool> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
            {
                var ids = request.Models.Select(x => x.Id).ToList();

                var questions = await unitOfWork.QuestionRepository.WhereAsync(x => ids.Contains(x.Id));
                var quizIds = questions.ToDictionary(q => q.Id, q => q.QuizId);

                if (questions.Count == 0) throw new BadRequestException("Không tim thấy câu hỏi!");

                unitOfWork.Mapper.Map(request.Models, questions);
                foreach (var question in questions)
                {
                    if (quizIds.TryGetValue(question.Id, out var quizId))
                    {
                        question.QuizId = quizId;
                    }
                }
                unitOfWork.QuestionRepository.UpdateRange(questions);
                return await unitOfWork.SaveChangesAsync();

            }
        }
    }
}
