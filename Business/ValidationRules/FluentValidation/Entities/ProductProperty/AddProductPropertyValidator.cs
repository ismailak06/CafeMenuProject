using Entities.Dtos.ProductProperty;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.Entities.ProductProperty
{
    public class AddProductPropertyValidator : AbstractValidator<AddProductPropertyDto>
    {
        public AddProductPropertyValidator()
        {
            RuleFor(p => p.ProductId).NotEmpty().WithMessage("Ürün boş geçilemez.");
            RuleFor(p => p.PropertyId).NotEmpty().WithMessage("Kategori boş geçilemez.");
        }
    }
}
