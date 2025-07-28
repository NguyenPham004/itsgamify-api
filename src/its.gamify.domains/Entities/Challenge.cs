namespace its.gamify.domains.Entities;

public class Challenge : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int NumOfRoom { get; set; }
    #region Navigation Properties
    public Guid CourseId { get; set; }
    public Course Course { get; set; }= null!;
    #endregion
}