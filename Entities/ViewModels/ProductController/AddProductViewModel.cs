using Entities.Concrete;
using Entities.Dtos.Category;
using Entities.Dtos.Product;
using Entities.Dtos.Property;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Entities.ViewModels.ProductController
{
    public class AddProductViewModel
    {
        public AddProductDto AddProductDto { get; set; }
        public IFormFile PhotoFile { get; set; }
        public IList<CategoriesDto> Categories { get; set; }
        public IList<PropertyDto> PropertiesDtos { get; set; }

    }
}
