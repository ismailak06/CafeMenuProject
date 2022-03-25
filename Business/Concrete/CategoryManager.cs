using Business.Abstract;
using Business.Utilities.AutoMapper;
using Business.ValidationRules.FluentValidation.Entities.Category;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Category;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<Category> Create(AddCategoryDto addCategoryDto)
        {
            var validator = new AddCategoryValidator();
            var validateResult = validator.Validate(addCategoryDto);
            if (!validateResult.IsValid)
            {
                var errorResults = ValidationHelper.GetErrors(validateResult.Errors);
                return new ErrorDataResult<Category>("Yeni kategori ekleme işlemi başarısız oldu.", errorResults);
            }
            var category = Mapping.Mapper.Map<Category>(addCategoryDto);
            var addedCategory = _categoryDal.Add(category);

            return new SuccessDataResult<Category>(addedCategory);
        }
        public IDataResult<Category> Update(EditCategoryDto updateCategoryDto)
        {
            var validator = new UpdateCategoryValidator();
            var validateResult = validator.Validate(updateCategoryDto);
            if (!validateResult.IsValid)
            {
                var errorResults = ValidationHelper.GetErrors(validateResult.Errors);
                return new ErrorDataResult<Category>("Kategori güncelleme işlemi başarısız oldu.", errorResults);
            }

            var category = _categoryDal.GetById(updateCategoryDto.Id);
            category.Name = updateCategoryDto.Name;
            category.ParentCategoryId = updateCategoryDto.ParentCategoryId;
            var updatedCategory = _categoryDal.Update(category);
            return new SuccessDataResult<Category>(updatedCategory);
        }

        public IDataResult<Category> Delete(int categoryId)
        {
            var category = _categoryDal.GetById(categoryId);
            var childCategories = CheckChildCategory(categoryId);

            foreach (var child in childCategories)
            {
                child.ParentCategoryId = null;
                _categoryDal.Update(child);
            }

            var deletedCategory = _categoryDal.Delete(category);
            return new SuccessDataResult<Category>(deletedCategory);
        }

        public IList<CategoriesDto> GetList()
        {
            return Mapping.Mapper.Map<List<CategoriesDto>>(_categoryDal.GetList(m => !m.IsDeleted));
        }

        public Category GetById(int categoryId)
        {
            return _categoryDal.GetById(categoryId);
        }

        public IList<Category> CheckChildCategory(int categoryId)
        {
            return _categoryDal.GetList(m => m.ParentCategoryId == categoryId);
        }
    }
}
