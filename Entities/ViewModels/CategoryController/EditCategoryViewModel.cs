using Entities.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels.CategoryController
{
    public class EditCategoryViewModel
    {
        public IList<CategoriesDto> Categories { get; set; }
        public EditCategoryDto EditCategoryDto { get; set; }
    }
}
