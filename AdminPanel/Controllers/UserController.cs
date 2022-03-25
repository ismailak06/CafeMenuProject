using Business.Abstract;
using Business.Utilities.AutoMapper;
using Entities.Dtos.User;
using Entities.ViewModels.UserController;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("list")]
        public IActionResult List()
        {
            ListUserViewModel model = new ListUserViewModel();
            model.UserDtos = _userService.GetList();
            return View(model);
        }

        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost, Route("add")]
        public IActionResult Add(AddUserViewModel model)
        {
            var addedUser = _userService.Create(model.AddUserDto);
            if (!addedUser.Success)
            {
                return View(model);
            }
            return RedirectToAction(nameof(List));
        }

        [Route("edit/{userId:int}")]
        public IActionResult Edit(int userId)
        {
            EditUserViewModel model = new EditUserViewModel();
            model.EditUserDto = Mapping.Mapper.Map<EditUserDto>(_userService.GetById(userId));
            return View(model);
        }
        [HttpPost, Route("edit/{userId:int}")]
        public IActionResult Edit(EditUserViewModel model)
        {
            var regulatedUser = _userService.Update(model.EditUserDto);
            if (!regulatedUser.Success)
            {
                return View(model);
            }
            return RedirectToAction(nameof(List));
        }

        [Route("delete/{userId:int}")]
        public IActionResult Delete(int userId)
        {
            var deletedUser = _userService.Delete(userId);
            return RedirectToAction(nameof(List));
        }

    }
}
