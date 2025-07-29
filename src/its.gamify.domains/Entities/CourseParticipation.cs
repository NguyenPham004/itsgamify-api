using System.Text.Json.Serialization;
using its.gamify.domains.Enums;

namespace its.gamify.domains.Entities;

public class CourseParticipation : BaseEntity
{
    [JsonPropertyName("enrolled_Date")]
    public DateTime EnrolledDate { get; set; }
    [JsonPropertyName("status")]
    public string Status { get; set; } = CourseParticipationStatusEnum.ENROLLED.ToString();
    [JsonPropertyName("user_id")]
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
    [JsonPropertyName("course_id")]
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; } = null!;
    public DateTime Deadline { get; set; }
    public virtual CourseResult? CourseResult { get; set; }
    public ICollection<LearningProgress> LearningProgresses { get; set; } = [];
    public virtual CourseReview? CourseReview { get; set; }
}