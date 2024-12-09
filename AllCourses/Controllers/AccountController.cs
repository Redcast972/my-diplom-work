using Microsoft.AspNetCore.Mvc;

namespace AllCourses.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Accessdenied()
        {
            return View();
        }

        //public IActionResult Logout() { }
    }
}
