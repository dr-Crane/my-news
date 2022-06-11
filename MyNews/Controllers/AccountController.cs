using Microsoft.AspNetCore.Mvc;
using MyNews.Models;
using MyNews.Models.ViewModels;
using MyNews.Services;
using System.Diagnostics;


namespace MyNews.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersService _usersService;

        public AccountController(IUsersService usersService)
        {
            _usersService = usersService;
        }


        public IActionResult LogIn()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _usersService.Register(model);
                    return RedirectToAction("Index", "Timeline");
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("RegistrationErrors", ex.Message);
                }
            }
            return View(model);
        }

    }
}
