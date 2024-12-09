using Microsoft.AspNetCore.Mvc;

namespace AllCourses.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
