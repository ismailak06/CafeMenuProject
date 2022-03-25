using Business.Abstract;
using Business.Utilities.AutoMapper;
using Entities.Dtos.Category;
using Entities.ViewModels.CategoryController;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers
{
    [Route("category")]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("list")]
        public IActionResult List()
        {
            ListCategoriesViewModel model = new ListCategoriesViewModel();

            model.CategoriesDtos = _categoryService.GetList();
            return View(model);
        }

        [Route("add")]
        public IActionResult AddCategory()
        {
            AddCategoryViewModel model = new AddCategoryViewModel();
            model.Categories = _categoryService.GetList();
            return View(model);
        }

        [HttpPost, Route("add")]
        public IActionResult AddCategory(AddCategoryViewModel model)
        {
            var addedCategory = _categoryService.Create(model.AddCategoryDto);
            if (!addedCategory.Success)
            {
                model.Categories = _categoryService.GetList();
                return View(model);
            }
            return RedirectToAction(nameof(List));
        }

        [Route("edit/{categoryId:int}")]
        public IActionResult Edit(int categoryId)
        {
            EditCategoryViewModel model = new EditCategoryViewModel();
            model.Categories = _categoryService.GetList();
            model.EditCategoryDto = Mapping.Mapper.Map<EditCategoryDto>(_categoryService.GetById(categoryId));
            return View(model);
        }

        [HttpPost, Route("edit/{categoryId:int}")]
        public IActionResult Edit(EditCategoryViewModel model)
        {
            var regulatedCategory = _categoryService.Update(model.EditCategoryDto);
            if (!regulatedCategory.Success)
            {
                model.Categories = _categoryService.GetList();
                return View(model);
            }
            return RedirectToAction(nameof(List));
        }

        [Route("delete/{categoryId:int}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            var deletedCategory = _categoryService.Delete(categoryId);

            return RedirectToAction(nameof(List));
        }
    }
}
