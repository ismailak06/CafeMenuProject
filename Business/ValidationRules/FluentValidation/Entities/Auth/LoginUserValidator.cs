using Business.Abstract;
using Core.Utilities.Security.Hashing;
using Entities.Dtos.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Entities.Auth
{
    public class LoginUserValidator : AbstractValidator<LoginUserDto>
    {
        private IUserService _userService;
        public LoginUserValidator(IUserService userService)
        {
            _userService = userService;
            RuleFor(m => m.Username).NotEmpty().WithMessage("Kullanıcı adı giriniz.").Must((m, username) => CheckValidUsername(m.Username)).WithMessage("Geçersiz kullanıcı adı.");
            RuleFor(m => m.Password).NotEmpty().WithMessage("Kullanıcı adı giriniz.").Must((m, password) => CheckValidPassword(m.Username, m.Password)).WithMessage("Hatalı şifre.");
        }

        private bool CheckValidUsername(string username)
        {
            return _userService.CheckExistsUserName(username).Data;
        }
        private bool CheckValidPassword(string username, string password)
        {
            var user = _userService.GetByUserName(username);
            if (user != null)
            {
                return (HashingHelper.VerifyPasswordHash(password, user.HashPassword, user.SaltPassword));
            }
            return true;
        }
    }
}
