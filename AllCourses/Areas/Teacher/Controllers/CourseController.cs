using AllCourses.Areas.Teacher.Models;
using Microsoft.AspNetCore.Mvc;

namespace AllCourses.Areas.Teacher.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCourse()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> AddCourse(CreateCourseViewModel model)
        //{
        
        //}
    }
}
