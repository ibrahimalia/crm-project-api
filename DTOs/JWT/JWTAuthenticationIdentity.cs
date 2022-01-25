using System.Security.Principal;

namespace Meta.IntroApp.DTOs.JWT
{
    public class JWTAuthenticationIdentity : GenericIdentity
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Role { get; set; }

        public JWTAuthenticationIdentity(string userName, string UserId, string role) : base(UserId)

        {
            UserName = userName;
            this.UserId = UserId;
            this.Role = role;
        }
    }
}