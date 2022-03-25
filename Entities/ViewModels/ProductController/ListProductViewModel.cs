using Entities.Dtos.Category;
using Entities.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.ProductController
{
    public class ListProductViewModel
    {
        public IList<ProductDto> ProductsDtos { get; set; }
        public IList<CategoriesDto> Categories { get; set; }

    }
}
