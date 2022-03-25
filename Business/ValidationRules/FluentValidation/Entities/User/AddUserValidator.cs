using Business.Abstract;
using Entities.Dtos.User;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.Entities.User
{
    public class AddUserValidator : AbstractValidator<AddUserDto>
    {
        private IUserService _userService;
        public AddUserValidator(IUserService userService)
        {
            _userService = userService;
            RuleFor(m => m.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez.");
            RuleFor(m => m.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez.");
            RuleFor(m => m.Username).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez.").Must((m, userName) => !ChechkExistsUserName(m.Username)).WithMessage("Bu kullanıcı adı zaten kullanılmaktadır.");
            RuleFor(m => m.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrarı alanı boş geçilemez.");
            RuleFor(m => m.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
            RuleFor(m => m).Must(m => m.Password == m.ConfirmPassword).WithMessage("Şifre ve şifre tekrarı alanı aynı olmalı.");

        }
        private bool ChechkExistsUserName(string userName)
        {
            return _userService.CheckExistsUserName(userName).Data;
        }
    }
}
