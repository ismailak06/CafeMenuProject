using Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.UserController
{
    public class ListUserViewModel
    {
        public IList<UserDto> UserDtos { get; set; }
    }
}
