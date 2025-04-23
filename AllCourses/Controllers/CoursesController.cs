using AllCourses.Domain;
using AllCourses.Domain.Entites.ApplicationsForTeaching;
using AllCourses.Domain.Entites.Courses;
using AllCourses.Domain.Repositories.Abstract;
using AllCourses.Models.Courses;
using AllCourses.Models.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace AllCourses.Controllers
{
    public class CoursesController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IApplicationsForTeachingRepository _applicationsForTeachingRepository;
        private readonly ICourseCategoryTypeRepository _courseCategoryTypeRepository;
        private AllCoursesDbContext _context;
        public CoursesController(IApplicationsForTeachingRepository applicationsForTeachingRepository, UserManager<IdentityUser> userMgr, ICourseCategoryTypeRepository courseCategoryTypeRepository, AllCoursesDbContext context)  
        {
            _applicationsForTeachingRepository = applicationsForTeachingRepository; 
            userManager = userMgr;
            _courseCategoryTypeRepository = courseCategoryTypeRepository;
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var courses = await _context.Courses.ToListAsync();

            return View(courses);
        }

        public async Task<IActionResult> DetailsOnlyForViewOrSubscribe(Guid id)
        {

            var course = await _context.Courses.FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.CourseId = id;
            return View(course);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.CourseId = id;
            return View(course);
        }

        [Authorize]
        [Route("[controller]/DetailsOnlyForViewOrSubscribe/{id}/subscribe")]
        public async Task<IActionResult> Subscribe(Guid id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(m => m.Id == id);
            IdentityUser user = await userManager.FindByNameAsync(User.Identity.Name);
            course.StudentsId.Add(user.Id);

            var usercourses = await _context.UsersCourses.FirstOrDefaultAsync(m => m.Username == user.UserName);
            var courseId = course.Id.ToString();

            if (usercourses == null || usercourses.CoursesId.Count == 0)
            {
                var coursesId = new List<string>();
                coursesId.Add(courseId);
                var userCourseEntityIfCourses0 = new UserCoursesEntity()
                {
                    UserId = Guid.Parse(user.Id),
                    Username = user.UserName,
                    CoursesId = coursesId,
                };

                await _context.UsersCourses.AddAsync(userCourseEntityIfCourses0);
            }
            else
            {
                usercourses.CoursesId.Add(courseId);
            }
            
            await _context.SaveChangesAsync();

            return Redirect($" ");
        }

        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> AddCourse()
        {
            var categories = await _courseCategoryTypeRepository.GetAllCourseCategoryTypesAsync();
            
            var model = new CreateCourseViewModel
            {

                CourseCategories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),  // ID категории
                    Text = c.CourseCategoryType // Название категории
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> AddCourse(CreateCourseViewModel model)
        {
            IdentityUser user = await userManager.FindByNameAsync(User.Identity.Name);
            using var memoryStream = new MemoryStream();
            await model.ImageFile.CopyToAsync(memoryStream);
            var imageBytes = memoryStream.ToArray();
            //Принимаем модельку созданного курса и сетим данные
            var course = new CourseEntity()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Discription = model.Discription,
                CourseCategory = model.CourseCategory,
                Author = User.Identity.Name,
                AuthorId = user.Id,
                ImageData = imageBytes,
                CreatedAt = DateTime.UtcNow,
                LessonsId = new List<string>(),
                StudentsId = new List<string>(),
                CommentariesId = new List<string>(),
                TestsId = new List<string>()
            };

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            return RedirectToAction("");
        }

        [Authorize(Roles = "teacher")]
        [Route("[controller]/Details/{id}/addlesson")]
        public async Task<IActionResult> AddLesson(Guid id)
        {
            ViewBag.CourseId = id;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "teacher")]
        [Route("[controller]/Details/{id}/addlesson")]
        public async Task<IActionResult> AddLesson(Guid id, [FromForm] AddLesonViewModel lesson)
        {
            using var memoryStream = new MemoryStream();
            await lesson.ImageFile.CopyToAsync(memoryStream);
            var imageBytes = memoryStream.ToArray();

            var lessonEntity = new LessonEntity()
            {
                Id = Guid.NewGuid(),
                CourseId = id.ToString(),
                Title = lesson.Title,
                Discription = lesson.Discription,
                LinksToVideoTutorials = new List<string>() { lesson.LinkToVideoTutorial },
                ImageData = imageBytes
            };

            var course = await _context.Courses.FindAsync(id);

            course.LessonsId.Add(lessonEntity.Id.ToString());

            _context.Lessons.Add(lessonEntity);
            await _context.SaveChangesAsync();

            //TODO: Перенастроить редирект на страницу преподавание и внихнуть юзернейм чтобы он коректно перенес
            return RedirectToAction("");
        }

        
        [Authorize(Roles = "teacher")]
        [Route("[controller]/Details/{id}/addtest")]
        public async Task<IActionResult> AddTest(Guid id)
        {
            ViewBag.CourseId = id;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "teacher")]
        [Route("[controller]/Details/{id}/addtest")]
        public async Task<IActionResult> AddTest(Guid id, [FromForm] TestEntity testFromForm)
        {            
            var test = new TestEntity()
            {
                Id = Guid.NewGuid(),
                CourseId = id,
                Question = testFromForm.Question,
                Answer1 = testFromForm.Answer1,
                Answer2 = testFromForm.Answer2,
                Answer3 = testFromForm.Answer3,
                CorrectAnswerNumber = testFromForm.CorrectAnswerNumber
            };

            var course = await _context.Courses.FindAsync(id);

            course.TestsId.Add(test.Id.ToString());

            await _context.Tests.AddAsync(test);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = id });
        }

        [Authorize(Roles = "teacher")]
        [Route("[controller]/Details/{courseId}/test/{testId}/view")]
        public async Task<IActionResult> ViewTest(Guid courseId, Guid testId)
        {
            //TODO:Реализовать просмотр теста
            //ViewBag.CourseId = id;
            return View();
        }

        [Authorize(Roles = "teacher")]
        [Route("[controller]/Details/{courseId}/test/{testId}/edit")]
        public async Task<IActionResult> EditTest(Guid courseId, Guid testId)
        {
            //TODO:Реализовать редактирование теста
            //ViewBag.CourseId = id;
            return View();
        }



        [Authorize(Roles = "student")]
        [Route("[controller]/get-access-to-create-courses")]
        public async Task<IActionResult> GetAccessToCreateCoursesAsync()
        {
            var user = await userManager.GetUserAsync(User);
            var application = await _applicationsForTeachingRepository.GetApplicationForTeachingByUserNameAsync(user.UserName);

            if (application == null)
            {
                return View();
            }

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

        [Authorize(Roles = "teacher")]
        public async Task<IActionResult> Teaching(string userName)
        {
            var courses = await _context.Courses.ToListAsync();

            var myCourses = courses
                .Where(f => f.Author == userName)
                .ToList();

            return View(myCourses);
        }

        [Authorize]
        public async Task<IActionResult> MyCourses(string userName)
        {
            var useresCourses = await _context.UsersCourses.ToListAsync();

            var myCoursesId = useresCourses
                .Where(f => f.Username == userName)
                .Select(f => f.CoursesId)
                .First();

            var myCourses = new List<CourseEntity>();

            foreach (var id in myCoursesId)
            {
                var course = await _context.Courses.Where(x => x.Id == Guid.Parse(id)).FirstOrDefaultAsync();
                myCourses.Add(course);
            }

            return View(myCourses);
        }
    }
}
