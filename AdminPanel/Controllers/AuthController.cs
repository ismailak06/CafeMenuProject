using AdminPanel.Functions.Validation.FluentValidation;
using Business.Abstract;
using Business.Utilities.Security;
using Core.Utilities.Results;
using Entities.Dtos.Category;
using Entities.Dtos.User;
using Entities.ViewModels.AuthController;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AdminPanel.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private IUserService _userService;
        private IAuthorizationHelper _authorizationHelper;

        public AuthController(IAuthorizationHelper authorizationHelper, IUserService userService)
        {
            _authorizationHelper = authorizationHelper;
            _userService = userService;
        }

        [Route("login")]
        public IActionResult Login()
        {
            LoginUserViewModel model = new LoginUserViewModel();
            return View(model);
        }

        [HttpPost, Route("login")]
        public IActionResult Login(LoginUserViewModel model)
        {
            ModelState.Clear();
            var login = _userService.CheckLogin(model.LoginUserDto);
            if (!login.Success)
            {
                ModelState.ValidateModel(login.ValidationErrors, nameof(LoginUserDto));
                return View(model);
            }
            _authorizationHelper.SignIn(login.Data);

            return Redirect("/");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
    }
}
