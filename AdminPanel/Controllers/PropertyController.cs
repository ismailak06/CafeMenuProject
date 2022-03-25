using Business.Abstract;
using Business.Utilities.AutoMapper;
using Entities.Dtos.Property;
using Entities.ViewModels.PropertyController;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers
{
    [Route("property")]
    public class PropertyController : Controller
    {
        private IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [Route("list")]
        public IActionResult List()
        {
            ListPropertyViewModel model = new ListPropertyViewModel();
            model.PropertiesDtos = _propertyService.GetList();
            return View(model);
        }

        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost, Route("add")]
        public IActionResult Add(AddPropertyViewModel model)
        {
            var addedProperty = _propertyService.Create(model.AddPropertyDto);
            if (!addedProperty.Success)
            {
                return View();
            }
            return RedirectToAction(nameof(List));
        }

        [Route("edit/{propertyId:int}")]
        public IActionResult Edit(int propertyId)
        {
            EditPropertyViewModel model = new EditPropertyViewModel();
            model.EditPropertyDto = Mapping.Mapper.Map<EditPropertyDto>(_propertyService.GetById(propertyId));
            return View(model);
        }

        [HttpPost, Route("edit/{propertyId:int}")]
        public IActionResult Edit(EditPropertyViewModel model)
        {
            var regulatedProperty = _propertyService.Update(model.EditPropertyDto);
            if (!regulatedProperty.Success)
            {
                return View(model);
            }
            return RedirectToAction(nameof(List));
        }

        [Route("delete/{propertyId:int}")]
        public IActionResult Delete(int propertyId)
        {
            var deletedProperty = _propertyService.Delete(propertyId);

            return RedirectToAction(nameof(List));
        }
    }
}
