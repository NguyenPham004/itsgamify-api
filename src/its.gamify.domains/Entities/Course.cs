using its.gamify.domains.Enums;

namespace its.gamify.domains.Entities;

public class Course : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public double DurationInHours { get; set; } = 0.0;
    public string Description { get; set; } = string.Empty;
    public string LongDescription { get; set; } = string.Empty;
    public CourseTypeEnum CourseType { get; set; } = CourseTypeEnum.All;
    public List<string> Tags { get; set; } = [];
    public List<string> Medias { get; set; } = [];
    public virtual ICollection<CourseResult> CourseResults { get; set; } = [];
    public virtual ICollection<CourseParticipation> CourseParticipations { get; set; } = [];
    public virtual ICollection<CourseReview> CourseReviews { get; set; } = [];
    public virtual ICollection<CourseSection> CourseSections { get; set; } = [];
    public virtual ICollection<Practice> Practices { get; set; } = [];
    public virtual ICollection<LearningMaterial> LearningMaterials { get; set; } = [];
    public Guid QuarterId { get; set; }
    public virtual Quarter Quarter { get; set; } = null!;
    public Guid DifficultyLevelId { get; set; }
    public virtual Difficulty DifficultyLevel { get; set; } = null!;
    public virtual ICollection<WishList> WishLists { get; set; } = [];
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;

}