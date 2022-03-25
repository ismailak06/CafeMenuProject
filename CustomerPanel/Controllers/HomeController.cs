using Business.Abstract;
using CustomerPanel.Models;
using Entities.ViewModels.ProductController;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerPanel.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            ListProductViewModel model = new ListProductViewModel();
            model.ProductsDtos = _productService.GetListWithProperties().Data;
            model.Categories = _categoryService.GetList();
            return View(model);
        }



    }
}
