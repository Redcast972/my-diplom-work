using AllCourses.Domain.Repositories.Abstract;
using AllCourses.Models.Courses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AllCourses.Controllers
{
    public class CoursesController : Controller
    {
        public IApplicationsForTeachingRepository _applicationsForTeachingRepository;
        public CoursesController(IApplicationsForTeachingRepository applicationsForTeachingRepository)  
        {
            _applicationsForTeachingRepository = applicationsForTeachingRepository;    
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        [Authorize(Roles = "teacher")]
        public IActionResult AddCourse()
        {
            return View();
        }

        [Authorize(Roles = "student")]
        [Route("[controller]/get-access-to-create-courses")]
        public IActionResult GetAccessToCreateCourses()
        {
            return View();
        }

        [HttpPost]
        [Route("[controller]/get-access-to-create-courses")]
        [Authorize(Roles = "student")]
        public async Task<IActionResult> GetAccessToCreateCourses(GetAccessToCreateCoursesViewModel model)
        {
                           
        }
    }
}
