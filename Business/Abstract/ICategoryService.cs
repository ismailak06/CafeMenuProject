using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Category;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> Create(AddCategoryDto addCategoryDto);
        IDataResult<Category> Update(EditCategoryDto updateCategoryDto);
        IDataResult<Category> Delete(int categoryId);
        IList<CategoriesDto> GetList();
        Category GetById(int categoryId);

        IList<Category> CheckChildCategory(int categoryId);
    }
}
