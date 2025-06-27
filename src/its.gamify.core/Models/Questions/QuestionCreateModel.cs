namespace its.gamify.core.Models.Questions
{
    public class QuestionCreateModel : QuestionUpsertModel
    {

        public Guid QuestionBankId { get; set; } = Guid.Empty;
        public Guid QuizId { get; set; } = Guid.Empty;
    }
}
