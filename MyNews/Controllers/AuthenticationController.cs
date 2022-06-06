using Microsoft.AspNetCore.Mvc;
using MyNews.Models;
using System.Diagnostics;


namespace MyNews.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
