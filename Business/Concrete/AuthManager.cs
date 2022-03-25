using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.Dtos.User;
using System;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;

        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }
        public IDataResult<User> LoginUser(LoginUserDto loginUserDto)
        {
            var user = _userService.GetUserByUserName(loginUserDto);
            if (user == null)
            {
                return new ErrorDataResult<User>("Kullanıcı bulunamadı.");
            }
            if (!HashingHelper.VerifyPasswordHash(loginUserDto.Password, user.HashPassword, user.SaltPassword))
            {
                return new ErrorDataResult<User>("Hatalı şifre.");
            }

            return new SuccessDataResult<User>(user, "Giriş başarılı.");
        }
    }
}
