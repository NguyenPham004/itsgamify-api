using its.gamify.domains.Enums;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace its.gamify.domains.Entities;

public class User : BaseEntity
{
    [JsonPropertyName("password")]
    public string? HashedPassword { get; set; } = string.Empty;
    [JsonPropertyName("salt")]
    public byte[]? Salt { get; set; } = null;
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; } = null;
    [JsonPropertyName("date_joined")]
    public DateTime? DateJoined { get; set; } = null;
    [JsonPropertyName("date_of_birth")]
    public DateTime? DateOfBirth { get; set; } = null;
    public string Status { get; set; } = UserStatusEnum.ACTIVE.ToString();
    public string? AvatarUrl { get; set; }


    #region  Relationship Configuration 
    public Guid RoleId { get; set; }
    public virtual Role? Role { get; set; }
    public ICollection<UserMetric>? UserMetrics { get; set; }
    public virtual ICollection<CourseParticipation>? CourseParticipations { get; set; }
    public virtual ICollection<Badge>? Badges { get; set; }
    public virtual ICollection<CourseResult> CourseResults { get; set; } = [];
    public virtual ICollection<Notification> Notifications { get; set; } = [];
    public virtual ICollection<UserChallengeHistory>? UserChallengeHistories { get; set; } = [];
    
    public Guid? DepartmentId { get; set; }
    public virtual Department? Department { get; set; }

    #endregion




}