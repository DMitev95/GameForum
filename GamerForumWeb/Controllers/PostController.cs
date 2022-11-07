using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Post;
using GamerForumWeb.Models;
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
        public async Task<IActionResult> Add(PostModel model)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await postService.AddPost(model, userId);

                return RedirectToAction("All", "Post");
            }
            catch (Exception e )
            {
                var erroMassage = new ErrorViewModel { RequestId = e.Message };
                return View("Error", erroMassage);
            }          
        }

        public async Task<IActionResult> Delete(int postId)
        {
            await postService.DeletePost(postId);

            return RedirectToAction(nameof(All));
        }

    }
}
