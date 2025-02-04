using AllCourses.Models;
using AllCourses.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using AllCourses.Domain.Entites;
using Microsoft.AspNetCore.Authorization;
using AllCourses.Models.News;

namespace AllCourses.Controllers
{
    public class NewsController : Controller
    {
        INewsRepository _newsRepository;
        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var newsList = await _newsRepository.GetAllNewsAsync();

            var news = newsList.Select(n => new NewsViewModel
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

        [Authorize(Roles = "admin")]
        public IActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddNews(CreateNewsViewModel model)
        {
            // Проверка, что файл выбран
            if (model.ImageFile == null || model.ImageFile.Length == 0)
            {
                ModelState.AddModelError("ImageFile", "Вы не выбрали изображение.");
                return View(model);
            }

            // Проверка размера файла (например, 5 MB)
            if (model.ImageFile.Length > 5 * 1024 * 1024)
            {
                ModelState.AddModelError("ImageFile", "Размер файла не должен превышать 5 MB.");
                return View(model);
            }

            // Копирование файла в память
            using var memoryStream = new MemoryStream();
            await model.ImageFile.CopyToAsync(memoryStream);
            var imageBytes = memoryStream.ToArray();

            // Создание сущности новости
            var newsEntity = new NewsEntity
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Discription,
                CreatedAt = DateTime.UtcNow,
                ImageData = imageBytes,
                ImageContentType = model.ImageFile.ContentType
            };

            // Создание новости в базе данных
            await _newsRepository.CreateNewsAsync(newsEntity);

            return RedirectToAction("Index");
        }
    }
}
