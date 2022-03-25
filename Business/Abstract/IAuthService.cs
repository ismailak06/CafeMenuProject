using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.User;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> LoginUser(LoginUserDto loginUserDto);
    }
}
