using Microsoft.AspNetCore.Mvc;

namespace AllCourses.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();  
        }
    }
}
