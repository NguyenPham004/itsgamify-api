namespace its.gamify.core.Models.QuizAnswers
{
    public class QuizAnswerCreateModel
    {
        public string? Answer { get; set; } = string.Empty;
        public Guid QuestionId { get; set; }
    }
}
