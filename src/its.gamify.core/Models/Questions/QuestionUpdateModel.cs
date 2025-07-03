using System.Text.Json.Serialization;

namespace its.gamify.core.Models.Questions
{
    public class QuestionUpdateModel : QuestionCreateModel
    {
        public Guid Id { get; set; }
    }

    public class QuestionUpsertModel
    {
        public string Content { get; set; } = string.Empty;
        [JsonPropertyName("answer_a")]
        public string OptionA { get; set; } = string.Empty;
        [JsonPropertyName("answer_b")]
        public string OptionB { get; set; } = string.Empty;
        [JsonPropertyName("answer_c")]
        public string OptionC { get; set; } = string.Empty;
        [JsonPropertyName("answer_d")]
        public string OptionD { get; set; } = string.Empty;
        [JsonPropertyName("correct_answer")]
        public string CorrectAnswer { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Explanation { get; set; } = string.Empty;
        public int Index { get; set; }
    }

}
