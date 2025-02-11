using AllCourses.Domain.Entites.ApplicationsForTeaching;
using AllCourses.Domain.Repositories.Abstract;
using AllCourses.Models.Courses;
using AllCourses.Models.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AllCourses.Controllers
{
    public class CoursesController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        public IApplicationsForTeachingRepository _applicationsForTeachingRepository;
        public CoursesController(IApplicationsForTeachingRepository applicationsForTeachingRepository, UserManager<IdentityUser> userMgr)  
        {
            _applicationsForTeachingRepository = applicationsForTeachingRepository; 
            userManager = userMgr;
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
        public async Task<IActionResult> GetAccessToCreateCoursesAsync()
        {
            var user = await userManager.GetUserAsync(User);
            var application = await _applicationsForTeachingRepository.GetApplicationForTeachingByUserNameAsync(user.UserName);

            if (application != null)
            {
                return RedirectToAction("CreateApplicationAccessDenied");
            }
            return View();
        }

        [Authorize(Roles = "student")]
        [Route("[controller]/awaiting-approval")]
        public IActionResult AwaitingApproval()
        {
            return View();
        }

        [Authorize(Roles = "student")]
        [Route("[controller]/create-application-access-denied")]
        public IActionResult CreateApplicationAccessDenied()
        {
            return View();
        }

        [HttpPost]
        [Route("[controller]/get-access-to-create-courses")]
        [Authorize(Roles = "student")]
        public async Task<IActionResult> GetAccessToCreateCourses(GetAccessToCreateCoursesViewModel model)
        {
            var user = await userManager.GetUserAsync(User);

            var application = new ApplicationForTeachingEntity
            {
                Id = Guid.NewGuid(),
                Description = model.Discription,
                UserName = user.UserName,
                UserEmail= user.Email,
                CreatedAt = DateTime.UtcNow,
            };
            
            await _applicationsForTeachingRepository.CreateApplicationForTeachingAsync(application);
            return RedirectToAction("AwaitingApproval");
        }

        [Authorize(Roles = "admin")]
        [Route("[controller]/applications-to-teaching")]
        public async Task<IActionResult> ApplicationsToTeachingList()
        {
            var applicationsToTeachingList = await _applicationsForTeachingRepository.GetAllApplicationsForTeachingAsync();

            var applications = applicationsToTeachingList.Select(n => new ApplicationToTeachingViewModel
            {
                Id = n.Id,
                UserName= n.UserName,
                UserEmail = n.UserEmail,
                CreatedAt = n.CreatedAt,
               
            })
             .ToList();

            return View(applications);
        }

        [Authorize(Roles = "admin")]
        [Route("[controller]/applications-to-teaching/{id}")]
        public IActionResult ApplicationsToTeaching(Guid id)
        {
            return View();
        }
    }
}
