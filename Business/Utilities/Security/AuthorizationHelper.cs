using Business.Extensions;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Security
{
    public class AuthorizationHelper : IAuthorizationHelper
    {
        IHttpContextAccessor _httpContextAccessor;

        public AuthorizationHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<Claim> SetUserClaims(UserDto userDto)
        {
            var claims = new List<Claim>();

            claims.AddUserId(userDto.Id.ToString());
            claims.AddName(userDto.Name);
            claims.AddSurname(userDto.Surname);
            claims.AddUsername(userDto.Username);

            return claims;
        }

        public void SignIn(UserDto userDto)
        {
            var claims = SetUserClaims(userDto);
            ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            AuthenticationProperties authProperties = new AuthenticationProperties();
            authProperties.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7);
            _httpContextAccessor.HttpContext.SignInAsync(scheme: "AdminSecurityScheme", principal: principal, properties: authProperties);
        }
    }
}
