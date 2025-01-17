using Microsoft.AspNetCore.Mvc;

namespace AllCourses.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddNews()
        {
            return View();
        }

        //[HttpPost]
        //public Task<IActionResult> AddNews()
        //{
            
        //}
    }
}
