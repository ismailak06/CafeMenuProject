using Entities.Concrete;
using Entities.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.CategoryController
{
    public class AddCategoryViewModel
    {
        public IList<CategoriesDto> Categories { get; set; }
        public AddCategoryDto AddCategoryDto { get; set; }
    }
}
