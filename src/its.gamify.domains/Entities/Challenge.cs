namespace its.gamify.domains.Entities;

public class Challenge : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int NumOfRoom { get; set; }
    public string ThumbnailImage { get;set; }= string.Empty;
    #region Navigation Properties
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    public Guid CourseId { get; set; }
    public Course Course { get; set; } = null!;
    public ICollection<UserChallengeHistory>? UserChallengeHistories { get; set; } = [];
    public ICollection<Room> Rooms { get; set; } = [];
    #endregion
}