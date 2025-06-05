using Hexagon.Domain.Entites.Forum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hexagon.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> CreateDiscussion()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateDiscussion(DiscussionEntity discussion)
        {

            //TODO: Реализовать логику создания дискуссии
            return View();
        }
    }
}
