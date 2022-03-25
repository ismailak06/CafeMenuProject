using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.User;
using System.Collections;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> Create(AddUserDto addUserDto);
        IDataResult<User> Update(EditUserDto updateUserDto);
        IDataResult<User> Delete(int userId);
        IDataResult<bool> CheckExistsUserName(string userName);
        IList<UserDto> GetList();
        User GetUserByUserName(LoginUserDto loginUserDto);
        UserDto GetById(int userId);
        IDataResult<UserDto> CheckLogin(LoginUserDto loginUserDto);

    }
}
