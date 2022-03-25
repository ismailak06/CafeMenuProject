using Business.Abstract;
using Business.Utilities.AutoMapper;
using Entities.Dtos.Product;
using Entities.ViewModels.ProductController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AdminPanel.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private IPropertyService _propertyService;
        private IProductPropertyService _productPropertyService;
        public ProductController(IProductService productService, ICategoryService categoryService, IPropertyService propertyService, IProductPropertyService productPropertyService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _propertyService = propertyService;
            _productPropertyService = productPropertyService;
        }

        [Route("list")]
        public IActionResult List()
        {
            ListProductViewModel model = new ListProductViewModel();
            model.ProductsDtos = _productService.GetListWithProperties().Data;
            model.Categories = _categoryService.GetList();
            return View(model);
        }

        [Route("add")]
        public IActionResult Add()
        {
            AddProductViewModel model = new AddProductViewModel();
            model.Categories = _categoryService.GetList();
            model.PropertiesDtos = _propertyService.GetList();
            return View(model);
        }

        [HttpPost, Route("add")]
        public async Task<IActionResult> Add(AddProductViewModel model, int[] propertyIds)
        {
            var newPhotoName = SavePhoto(model.PhotoFile);
            model.AddProductDto.ImagePath = await newPhotoName;

            var addedProduct = _productService.Create(model.AddProductDto);
            if (!addedProduct.Success)
            {
                model.Categories = _categoryService.GetList();
                return View(model);
            }
            _productPropertyService.UpdateAll(propertyIds, addedProduct.Data.Id);

            return RedirectToAction(nameof(List));
        }

        [Route("edit/{productId:int}")]
        public IActionResult Edit(int productId)
        {
            EditProductViewModel model = new EditProductViewModel();
            model.EditProductDto = Mapping.Mapper.Map<EditProductDto>(_productService.GetById(productId).Data);
            model.Categories = _categoryService.GetList();
            model.PropertiesDtos = _propertyService.GetList();
            model.ProductPropertyDtos = _productPropertyService.GetListByProductId(productId);
            return View(model);
        }

        public async Task<string> SavePhoto(IFormFile file)
        {
            string newPhotoName = Guid.NewGuid().ToString() + ".jpeg";
            string fileExtension = Path.GetExtension(file.FileName);
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "content", "img", newPhotoName);

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                using (Image image = Image.Load(file.OpenReadStream()))
                {
                    image.SaveAsJpeg(memoryStream);
                    image.Mutate(x => x.BackgroundColor(Color.White));
                    await image.SaveAsync(filePath);
                }
            }
            return newPhotoName;
        }

        [HttpPost, Route("edit/{productId:int}")]
        public IActionResult Edit(EditProductViewModel model, int[] propertyIds)
        {
            var regulatedProduct = _productService.Update(model.EditProductDto);

            if (!regulatedProduct.Success)
            {
                model.Categories = _categoryService.GetList();
                return View(model);
            }
            _productPropertyService.UpdateAll(propertyIds, regulatedProduct.Data.Id);
            return RedirectToAction(nameof(List));
        }

        [Route("delete/{productId:int}")]
        public IActionResult Delete(int productId)
        {
            var deletedProduct = _productService.Delete(productId);
            return RedirectToAction(nameof(List));
        }


    }
}
