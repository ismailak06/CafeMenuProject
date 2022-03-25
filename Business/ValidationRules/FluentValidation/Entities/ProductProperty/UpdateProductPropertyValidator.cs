using Entities.Dtos.ProductProperty;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Entities.ProductProperty
{
    public class UpdateProductPropertyValidator : AbstractValidator<EditProductPropertyDto>
    {
        public UpdateProductPropertyValidator()
        {
            RuleFor(p => p.ProductId).NotEmpty().WithMessage("Ürün boş geçilemez.");
            RuleFor(p => p.PropertyId).NotEmpty().WithMessage("Kategori boş geçilemez.");
        }
    }
}
