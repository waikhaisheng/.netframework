using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Models.CommonModels;
using Models.Enums;

namespace WebApplication.Filters
{
    /// <summary>
    /// Creater: Wai Khai Sheng
    /// Created: 20211223
    /// UpdatedBy:
    /// Updated:
    //System.IdentityModel.Tokens.Jwt
    /// </summary>
    public class JwtAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        private static string Secret = ConfigurationManager.AppSettings["JwtSecret"];
        public bool AllowMultiple => throw new NotImplementedException();
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            await TaskToRunAsync();
            IPrincipal principal = null;
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != "Bearer" || string.IsNullOrEmpty(authorization.Parameter))
            {
                var response = new ResponseBase(ApiStatusEnum.Error, "Missing Jwt Token");
                context.ErrorResult = new JwtAuthenticationFailureResult<ResponseBase>(request, response);
                return;
            }

            var token = authorization.Parameter;
            var validToken = ValidateToken(token, out string username);
            if (validToken)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
                var identity = new ClaimsIdentity(claims, "Jwt");
                principal = new ClaimsPrincipal(identity);
            }
            if (principal == null)
            {
                var response = new ResponseBase(ApiStatusEnum.Error, "Invalid token");
                context.ErrorResult = new JwtAuthenticationFailureResult<ResponseBase>(request, response);
                return;
            }
            else
                context.Principal = principal;
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="token"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        private static bool ValidateToken(string token, out string username)
        {
            username = null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null)
                return false;

            var symmetricKey = Convert.FromBase64String(Secret);
            var validationParameters = new TokenValidationParameters()
            {
                RequireExpirationTime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
            };

            var simplePrinciple = tokenHandler.ValidateToken(token, validationParameters, out _);
            var identity = simplePrinciple?.Identity as ClaimsIdentity;

            if (identity == null)
                return false;

            if (!identity.IsAuthenticated)
                return false;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim?.Value;

            if (string.IsNullOrEmpty(username))
                return false;

            return true;
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <returns></returns>
        private async Task TaskToRunAsync()
        {
            await Task.Run(() => { });
        }
        /// <summary>
        /// Creater: Wai Khai Sheng
        /// Created: 20211223
        /// UpdatedBy:
        /// Updated:
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}