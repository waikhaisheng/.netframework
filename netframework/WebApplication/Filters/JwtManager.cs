using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace WebApplication.Filters
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211223
    /// UpdatedBy:
    /// Updated:
    /// </summary>
    public static class JwtManager
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        private static string Secret = ConfigurationManager.AppSettings["JwtSecret"];
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="username"></param>
        /// <param name="expireHours"></param>
        /// <returns></returns>
        public static string GenerateToken(string username, int expireHours = 24)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]{ new Claim(ClaimTypes.Name, username) }),
                Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(expireHours)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }
    }
}