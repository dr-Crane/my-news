using Microsoft.AspNetCore.Mvc;
using MyNews.Models;
using System.Diagnostics;


namespace MyNews.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Test()
        {
            return Ok("Alright");
        }
    }
}
