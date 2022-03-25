using Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Security
{
    public interface IAuthorizationHelper
    {
        void SignIn(UserDto userDto);
        IEnumerable<Claim> SetUserClaims(UserDto userDto);
    }
}
