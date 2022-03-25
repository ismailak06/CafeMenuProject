using Entities.Dtos.Product;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.Entities.Product
{
    public class AddProductValidator : AbstractValidator<AddProductDto>
    {
        public AddProductValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Ürün adı boş geçilemez.");
            RuleFor(m => m.CategoryId).GreaterThan(0).WithMessage("Kategori seçiniz.");
            RuleFor(m => m.Price).GreaterThan(0).WithMessage("Fiyat giriniz.");
            RuleFor(m => m.ImagePath).NotEmpty().WithMessage("Fotoğraf ekleyiniz.");
        }
    }
}
