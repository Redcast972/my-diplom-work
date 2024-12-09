using Microsoft.AspNetCore.Mvc;

namespace AllCourses.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
