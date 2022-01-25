using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System;
using System.IdentityModel.Tokens.Jwt;

using System.Linq;
using System.Text;

namespace Meta.IntroApp.DTOs.JWT
{
    public class AuthenticationModule
    {
        public AuthenticationModule()
        {
        }

        public IConfiguration Configuration { get; set; }

        public AuthenticationModule(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        private const string Key = "u7x!A%D*G-KaPdSg";
        private SecurityKey signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));

        // The Method is used to generate token for user
        //public string GenerateTokenForUser(string userName, int userId)
        //{
        //    var signingKey = new InMemorySymmetricSecurityKey(Encoding.UTF8.GetBytes(communicationKey));
        //    var now = DateTime.UtcNow;
        //    var signingCredentials = new SigningCredentials(signingKey,
        //       SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);

        //    var claimsIdentity = new ClaimsIdentity(new List<Claim>()
        //    {
        //        new Claim(ClaimTypes.Name, userName),
        //        new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
        //    }, "Custom");

        //    var securityTokenDescriptor = new SecurityTokenDescriptor()
        //    {
        //        AppliesToAddress = "http://www.example.com",
        //        TokenIssuerName = "self",
        //        Subject = claimsIdentity,
        //        SigningCredentials = signingCredentials,
        //        Lifetime = new Lifetime(now, now.AddYears(1)),
        //    };

        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
        //    var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);

        //    return signedAndEncodedToken;

        //}

        /// Using the same key used for signing token, user payload is generated back

        /// Using the same key used for signing token, user payload is generated back
        public JwtSecurityToken GenerateUserClaimFromJWT(string authToken)
        {
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidAudiences = new string[]
                      {
                   "META"
                      },

                ValidIssuers = new string[]
                  {
                       "META",
                  },
                IssuerSigningKey = signingKey
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken validatedToken;

            try
            {
                tokenHandler.ValidateToken(authToken, tokenValidationParameters, out validatedToken);
            }
            catch (Exception)
            {
                return null;
            }

            return validatedToken as JwtSecurityToken;
        }

        public JWTAuthenticationIdentity PopulateUserIdentity(JwtSecurityToken userPayloadToken)
        {
            string Email = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == "Email").Value;
            string userId = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == "UserId").Value;
            string role = ((userPayloadToken)).Claims.FirstOrDefault(m => m.Type == "Role").Value;
            return new JWTAuthenticationIdentity(Email, userId, role) { UserId = userId, UserName = Email, Role = role };
        }
    }
}