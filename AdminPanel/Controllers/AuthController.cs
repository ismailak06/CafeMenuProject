using Business.Abstract;
using Business.Utilities.Security;
using Core.Utilities.Results;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AdminPanel.Controllers
{

    public class AuthController : Controller
    {
        private IUserService _userService;
        private IAuthorizationHelper _authorizationHelper;

        public AuthController(IAuthorizationHelper authorizationHelper, IUserService userService)
        {
            _authorizationHelper = authorizationHelper;
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserDto loginUserDto)
        {
            var login = _userService.CheckLogin(loginUserDto);
            if (!login.Success)
            {
                return View(login);
            }
            _authorizationHelper.SignIn(login.Data);
          
            return Json(true );
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
    }
}
