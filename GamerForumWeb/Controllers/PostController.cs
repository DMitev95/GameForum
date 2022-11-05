using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Game;
using GamerForumWeb.Core.Models.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamerForumWeb.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService _postService)
        {
            postService = _postService;
        }

        public async Task<IActionResult> All(int gameId)
        {
            var model = await postService.GetAllGamePost(gameId);

            return View(model);
        }


        [HttpGet]
        public IActionResult Add(int gameId)
        {
            var model = new PostModel()
            {
                GameId = gameId,
            };

            return View(model);

        }


        [HttpPost]
        //[Route("Add")]
        public async Task<IActionResult> Add(PostModel model)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await postService.AddPost(model, userId);

            return RedirectToAction(nameof(All));
        }

    }
}
