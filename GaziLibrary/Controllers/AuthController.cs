using AspNetCoreHero.ToastNotification.Abstractions;
using GaziLibrary.Business.Abstract;
using GaziLibrary.Entities.Concrete;
using GaziLibrary.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GaziLibrary.Controllers
{
    public class AuthController : Controller
    {
        INotyfService _notyf;
        IUserService _userService;
        IPositionService _positionService;
        public AuthController(INotyfService notyf, IUserService userService, IPositionService positionService)
        {
            _notyf = notyf;
            _userService = userService;
            _positionService = positionService;
        }

        // User Login
        public IActionResult Login()
        {
            var model = new UserModel
            {
                User = new User()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var result = _userService.CheckUser(user);
            if (!result.Success)
            {
                _notyf.Error("Hatalı Parola veya Kullanıcı Adı", 3);
                var model = new UserModel
                {
                    User = new User()
                };
                return View(model);
            }
            var result2 = _userService.GetByUsername(user.UserName);
            HttpContext.Session.SetString("id", result2.Data.Id.ToString());
            HttpContext.Session.SetString("name", result2.Data.FirstName);
            HttpContext.Session.SetString("lastname", result2.Data.LastName);
            HttpContext.Session.SetString("position", result2.Data.Position.Name);
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName) };
            var userIdentity = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);
            _notyf.Success("Hoşgeldiniz..", 3);
            if(result2.Data.Position.Name == "KULLANICI")
            {
                return RedirectToAction("Books", "User");
            }
            return RedirectToAction("Books", "Admin");
        }

        // User Signup
        public IActionResult UserSignup()
        {
            var model = new UserModel
            {
                User = new User()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UserSignup(User user)
        {
            user.Status = true;
            user.PositionId = _positionService.GetByName("KULLANICI").Data.Id;
            if (!ModelState.IsValid)
            {
                var model = new UserModel
                {
                    User = user
                };
                return View(model);
            }
            var result = _userService.Add(user);
            if(!result.Success)
            {
                _notyf.Error("Üye işlemi yapılırken bir hata oluştu.");
                var model = new UserModel
                {
                    User = new User()
                };
                return View(model);
            }
            _notyf.Success("Üye işlemi başarıyla tamamlandı.");
            return RedirectToAction("Login", "Auth");
        }

        // Logout
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("id");
            Response.Cookies.Delete("name");
            Response.Cookies.Delete("lastname");
            Response.Cookies.Delete("position");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
    }
}
