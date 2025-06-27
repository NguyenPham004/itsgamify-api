

namespace its.gamify.core.Models.Questions
{
    public class QuestionViewModel
    {
        public string Content { get; set; } = string.Empty;
        public string OptionA { get; set; } = string.Empty;
        public string OptionB { get; set; } = string.Empty;
        public string OptionC { get; set; } = string.Empty;
        public string OptionD { get; set; } = string.Empty;
        public string CorrectAnswer { get; set; } = string.Empty;
        public string Explanation { get; set; } = string.Empty;
        public Guid QuestionBankId { get; set; }
        public Guid QuizId { get; set; }
    }
}
