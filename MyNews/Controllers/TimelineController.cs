using Microsoft.AspNetCore.Mvc;
using MyNews.Services;

namespace MyNews.Controllers
{
    public class TimelineController : Controller
    {
        public IActionResult Index()
        {
            Scrapper scrap = new Scrapper();
            var result = scrap.Run();
            ViewBag.Message = result;
            return View();
        }
    }
}
