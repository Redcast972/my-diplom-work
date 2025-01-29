using AllCourses.Areas.Admin.Models;
using AllCourses.Domain;
using AllCourses.Domain.Entites;
using AllCourses.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AllCourses.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        INewsRepository _newsRepository;       
        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var newsList = await _newsRepository.GetAllNewsAsync();

               var news =  newsList.Select(n => new NewsViewModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Discription = n.Description,
                    CreatedAt = n.CreatedAt,
                    ImageData = n.ImageData
                })
                .ToList();

            return View(news);
        }

        public IActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNews(CreateNewsViewModel model)
        {
            using var memoryStream = new MemoryStream();
            await model.ImageFile.CopyToAsync(memoryStream);
            var imageBytes = memoryStream.ToArray();

            var newsEntity = new NewsEntity {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Discription,
                CreatedAt = DateTime.UtcNow,
                ImageData = imageBytes,
                ImageContentType =  model.ImageFile.ContentType
            }; 
            
            await _newsRepository.CreateNewsAsync(newsEntity);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var news = await _newsRepository.GetNewsByIdAsync(id);
            var newsViewModel = new NewsViewModel
            {
                Id = news.Id,
                Title = news.Title,
                Discription = news.Description,
                CreatedAt = news.CreatedAt,
                ImageData = news.ImageData,
            };
            return View(newsViewModel);
        }
    }
}
