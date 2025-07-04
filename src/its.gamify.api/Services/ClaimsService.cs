using its.gamify.core.Services.Interfaces;
using System.Security.Claims;

namespace its.gamify.api.Services;

public class ClaimsService : IClaimsService
{
    public ClaimsService(IHttpContextAccessor httpContextAccessor)
    {
        var userId = httpContextAccessor.HttpContext?.User?.FindFirstValue(claimType: ClaimTypes.NameIdentifier);
        CurrentUser = string.IsNullOrEmpty(userId) ? Guid.Empty : Guid.Parse(userId);
        var role = httpContextAccessor.HttpContext?.User?.FindFirstValue(claimType: ClaimTypes.Role);
        CurrentRole = role ?? string.Empty;
    }
    public Guid CurrentUser { get; }

    public string CurrentRole { get; }
}