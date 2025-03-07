using AllCourses.Domain.Entites.ApplicationsForTeaching;
using AllCourses.Domain.Entites.Courses;
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
        private readonly IApplicationsForTeachingRepository _applicationsForTeachingRepository;
        private readonly ICourseCategoryTypeRepository _courseCategoryTypeRepository;
        public CoursesController(IApplicationsForTeachingRepository applicationsForTeachingRepository, UserManager<IdentityUser> userMgr, ICourseCategoryTypeRepository courseCategoryTypeRepository)  
        {
            _applicationsForTeachingRepository = applicationsForTeachingRepository; 
            userManager = userMgr;
            _courseCategoryTypeRepository = courseCategoryTypeRepository;
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

            if (application.Status == "Отправлена на исполнение" || application.Status == "Принята")
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
                Status = "Отправлена на исполнение",
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
                Status  = n.Status,
               
            })
             .ToList();

            return View(applications);
        }

        [Authorize(Roles = "admin")]
        [Route("[controller]/applications-to-teaching/{id}")]
        public async Task<IActionResult> ApplicationToTeaching(Guid id)
        {
            var applicationEntity = await _applicationsForTeachingRepository.GetApplicationForTeachingByIdAsync(id);

            var application = new ApplicationToTeachingViewModel
            {
                Id= applicationEntity.Id,
                UserName= applicationEntity.UserName,
                UserEmail= applicationEntity.UserEmail,
                Description = applicationEntity.Description,
                CreatedAt = applicationEntity.CreatedAt,
                Status = applicationEntity.Status,
            };

            return View(application);
        }

        [Authorize(Roles = "admin")]
        [Route("[controller]/applications-to-teaching/{id}/reject")]
        public async Task<IActionResult> ApplicationToTeachingReject(Guid id)
        {
            var applicationEntity = await _applicationsForTeachingRepository.GetApplicationForTeachingByIdAsync(id);

            var rejectApplicationEntity = new ApplicationForTeachingEntity
            {
                Id = applicationEntity.Id,
                UserName = applicationEntity.UserName,
                UserEmail = applicationEntity.UserEmail,
                Description = applicationEntity.Description,
                CreatedAt = applicationEntity.CreatedAt,
                Status = "Отклонена",
            };

            await _applicationsForTeachingRepository.UpdateApplicationForTeachingAsync(rejectApplicationEntity);

            return RedirectToAction("ApplicationsToTeachingList");
        }

        [Authorize(Roles = "admin")]
        [Route("[controller]/applications-to-teaching/{id}/accept")]
        public async Task<IActionResult> ApplicationToTeachingAccept(Guid id)
        {
            var applicationEntity = await _applicationsForTeachingRepository.GetApplicationForTeachingByIdAsync(id);

            var acceptApplicationEntity = new ApplicationForTeachingEntity
            {
                Id = applicationEntity.Id,
                UserName = applicationEntity.UserName,
                UserEmail = applicationEntity.UserEmail,
                Description = applicationEntity.Description,
                CreatedAt = applicationEntity.CreatedAt,
                Status = "Принята",
            };

            await _applicationsForTeachingRepository.UpdateApplicationForTeachingAsync(acceptApplicationEntity);

            var user = await userManager.FindByEmailAsync(applicationEntity.UserEmail);

            if (user != null)
            {
                var roles = await userManager.GetRolesAsync(user);
                await userManager.RemoveFromRolesAsync(user, roles); // Удаляем старые роли

                var result = await userManager.AddToRoleAsync(user, "teacher"); // Добавляем новую роль
                if (result.Succeeded)
                {
                    return RedirectToAction("ApplicationsToTeachingList");
                }
            }

            return View("Error", "Ошибка при принятии заявки");
        }

        [Authorize(Roles = "admin")]
        [Route("[controller]/category-types")]
        public async Task<IActionResult> CourseCategoryTypesList()
        {
            var categoryTypes = await _courseCategoryTypeRepository.GetAllCourseCategoryTypesAsync(); 
            return View(categoryTypes);
        }


        [Authorize(Roles = "admin")]
        [Route("[controller]/category-types/add")]
        public async Task<IActionResult> AddCourseCategoryType()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("[controller]/category-types/add")]
        public async Task<IActionResult> AddCourseCategoryType(string courseCategoryType)
        {
            CourseCategoryTypeEntity courseCategory = new CourseCategoryTypeEntity()
            {
                Id= Guid.NewGuid(),
                CourseCategoryType = courseCategoryType
            };
            await _courseCategoryTypeRepository.CreateCourseCategoryTypeAsync(courseCategory);
            return RedirectToAction("CourseCategoryTypesList");
        }
    }
}
