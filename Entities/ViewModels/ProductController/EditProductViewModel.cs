using Entities.Dtos.Category;
using Entities.Dtos.Product;
using Entities.Dtos.ProductProperty;
using Entities.Dtos.Property;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.ProductController
{
    public class EditProductViewModel
    {
        public EditProductDto EditProductDto { get; set; }
        public IFormFile PhotoFile { get; set; }
        public IList<CategoriesDto> Categories { get; set; }
        public IList<PropertyDto> PropertiesDtos { get; set; }
        public IList<ProductPropertyDto> ProductPropertyDtos { get; set; }
    }
}
