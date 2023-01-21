using AdminPanel.Models;
using AdminPanel.Models.Helpers;
using AdminPanel.Models.ViewModel;
using AdminPanel.Service.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AdminPanel.Repository.Interfaces;
using AdminPanel.Service.Interfaces;

namespace AdminPanel.Controllers
{
    public class HomeController : Controller
    {

        private IUserService _userRepository;
        private IAccountService _accountService;

        public HomeController(IUserService userRepository, IAccountService accountService)
        {
            _userRepository = userRepository;
            _accountService = accountService;       
        }

        [HttpGet]
        public IActionResult Login() => View();
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Name == model.Name);
            if (ModelState.IsValid)
            {
                if (user.Password != HashPasswordHelper.HashPassword(model.Password))
                {
                    ViewBag.Error = "Неправильный пароль";
                }
                else
                {
                    if (user.Role == Models.Enum.Role.Admin)
                    {
                        var response = _accountService.Login(model);

                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response));

                        return RedirectToAction("Users", "User");
                    }
                }

            }
            return View("Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
