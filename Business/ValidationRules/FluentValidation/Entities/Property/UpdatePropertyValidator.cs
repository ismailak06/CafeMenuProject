using Entities.Dtos.Property;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.Entities.Property
{
    public class UpdatePropertyValidator : AbstractValidator<EditPropertyDto>
    {
        public UpdatePropertyValidator()
        {
            RuleFor(m => m.Key).NotEmpty().WithMessage("Anahtar boş geçilemez.");
            RuleFor(m => m.Value).NotEmpty().WithMessage("Değer boş geçilemez.");
        }
    }
}
