namespace its.gamify.domains.Entities;

public class Badge : BaseEntity
{
    public string Type { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    #region  RelationshipConfiguration
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
    #endregion
}