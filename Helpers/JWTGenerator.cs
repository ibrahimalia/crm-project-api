using Meta.IntroApp.DTOs.JWT;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Meta.IntroApp.Helpers
{
    public static class JWTGenerator
    {
        public static TokenDTO GenerateJWTToken(TokenClaimsInfoDTO userInfo, IConfiguration appSettings)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userInfo.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Email),
                //new Claim("role", userInfo.Role)
            
                
            };
            // my update on code
            for (int i = 0; i < (userInfo?.Role?.Count ?? 0); i++)
            {
                var claim = new Claim(ClaimTypes.Role, userInfo.Role[i]);
                claims.Add(claim);
            }
            // end my update on code
               

            var token = new JwtSecurityToken(
                issuer: appSettings["Jwt:Issuer"],
                audience: appSettings["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials
            );
            string toko = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenDTO
            {
                AccessToken = "Bearer " + toko,
                ExpiresIn = DateTime.Now.AddDays(7).Subtract(DateTime.Now).Seconds,
                RefreshToken = "",
            };
        }


    }
}
