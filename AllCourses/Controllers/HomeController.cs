using AllCourses.Domain.Repositories.Abstract;
using AllCourses.Models.News;
using Microsoft.AspNetCore.Mvc;

namespace AllCourses.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsRepository _newsRepository;

        public HomeController(ILogger<HomeController> logger, INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var newsList = await _newsRepository.GetAllNewsAsync();

            var news = newsList
                .OrderByDescending(n => n.CreatedAt) // Сортировка от новых к старым
                .Take(2) // Берем последние две новости
                .Select(n => new NewsViewModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Discription = n.Description,
                    CreatedAt = n.CreatedAt,
                    ImageData = n.ImageData
                }).ToList();
            return View(news);
        }

        public IActionResult About()
        {
            return View();
        }

    }
}
