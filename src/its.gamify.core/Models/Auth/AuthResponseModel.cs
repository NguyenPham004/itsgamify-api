using its.gamify.core.Models.Users;

namespace its.gamify.core.Models.Auth
{
    public class AuthResponseModel
    {
        public UserViewModel User { get; set; } = null!;
        public string Token { get; set; } = string.Empty;
    }
}
