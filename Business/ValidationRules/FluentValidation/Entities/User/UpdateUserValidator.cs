using Business.Abstract;
using Entities.Dtos.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Entities.User
{
    public class UpdateUserValidator : AbstractValidator<EditUserDto>
    {
        private IUserService _userService;
        public UpdateUserValidator(IUserService userService)
        {
            _userService = userService;

            RuleFor(m => m.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez.");
            RuleFor(m => m.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez.");
        }
    }
}
