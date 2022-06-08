using Microsoft.AspNetCore.Mvc;

namespace MyNews.Controllers
{
    public class TimelineController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
