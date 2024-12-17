using Microsoft.AspNetCore.Mvc;

namespace AllCourses.Controllers
{
    public class ErrorController : Controller
    {
        // Страница ошибки 404
        public IActionResult NotFound()
        {
            return View();
        }

        // Страница ошибки 500
        public IActionResult ServerError()
        {
            return View();
        }
    }
}
