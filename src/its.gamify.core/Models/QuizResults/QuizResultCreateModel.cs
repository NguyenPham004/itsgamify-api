
using its.gamify.core.Models.QuizAnswers;
using its.gamify.domains.Enums;

namespace its.gamify.core.Models.QuizResults
{
    public class QuizResultCreateModel
    {
        public Guid ParticipationId { get; set; }
        public Guid QuizId { get; set; }
        public Guid TypeId { get; set; }
        public string Type { get; set; } = QUIZ_RESULT_TYPE.LESSON;
        public List<QuizAnswerCreateModel> Answers { get; set; } = [];
    }
}
