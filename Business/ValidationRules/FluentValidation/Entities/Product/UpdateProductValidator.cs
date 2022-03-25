using Entities.Dtos.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.Entities.Product
{
    public class UpdateProductValidator : AbstractValidator<EditProductDto>
    {
        public UpdateProductValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage("Ürün adı boş geçilemez.");
            RuleFor(m => m.CategoryId).GreaterThan(0).WithMessage("Kategori seçiniz.");
            RuleFor(m => m.Price).GreaterThan(0).WithMessage("Fiyat giriniz.");
        }
    }
}
