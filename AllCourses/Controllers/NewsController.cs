using Microsoft.AspNetCore.Mvc;

namespace AllCourses.Controllers
{
    public class NewsController : Controller
    {
        public NewsController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
