using System.Text.Json.Serialization;

namespace its.gamify.domains.Entities;

public class Question : BaseEntity
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
    public bool IsHidden { get; set; } = false;
    [JsonPropertyName("quiz_id")]
    public Guid QuizId { get; set; }
    public virtual Quiz Quiz { get; set; } = null!;
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; } = null!;
    public ICollection<QuizAnswer> QuizAnswers { get; set; } = [];


}