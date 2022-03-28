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
        IDataResult<bool> CheckExistsUserName(string username);
        IList<UserDto> GetList();
        User GetByUserName(string username);
        UserDto GetById(int userId);
        IDataResult<UserDto> CheckLogin(LoginUserDto loginUserDto);
    }
}
