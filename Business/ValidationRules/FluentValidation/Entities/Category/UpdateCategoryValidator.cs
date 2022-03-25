using Entities.Dtos.Category;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Entities.Category
{
    public class UpdateCategoryValidator : AbstractValidator<EditCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Kategory adı boş geçilemez.");
        }
    }
}
