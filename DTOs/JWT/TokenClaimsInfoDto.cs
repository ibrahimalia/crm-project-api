using System.Collections.Generic;

namespace Meta.IntroApp.DTOs.JWT
{
    public class TokenClaimsInfoDTO
    {
        public long UserId { get; set; }

        //public string Username { get; set; }
        public string Email { get; set; }

        public List<string> Role { get; set; }
        //public UserType UserType { get; set; }
    }
}