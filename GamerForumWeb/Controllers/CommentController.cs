using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Comment;
using GamerForumWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamerForumWeb.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService _commentService)
        {
            commentService = _commentService;
        }

        [HttpGet]
        public IActionResult Add(int postId)
        {
            var model = new CommentModel()
            {
                PostId = postId,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommentModel model)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await commentService.AddComment(model, userId);
                return RedirectToAction("All", new { id = model.PostId });
            }
            catch (Exception e)
            {
                var erroMassage = new ErrorViewModel { RequestId = e.Message };
                return View("Error", erroMassage);
            }

        }

        public async Task<IActionResult> All(int id)
        {
            try
            {
                var model = await commentService.AllComments(id);

                return View(model);
            }
            catch (Exception e)
            {
                var erroMassage = new ErrorViewModel { RequestId = e.Message };
                return View("Error", erroMassage);
            }

        }

        public async Task<IActionResult> Delete(int commentId)
        {
            await commentService.DeleteComment(commentId);

            return RedirectToAction("All", "Game");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int commentId)
        {
            var comment = await commentService.GetCommentById(commentId);

            return View(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int commentId, CommentModel model)
        {

            try
            {
                await commentService.UpdateComment(commentId, model);

                return RedirectToAction("All", "Game");
            }
            catch (Exception e)
            {
                var erroMassage = new ErrorViewModel { RequestId = e.Message };
                return View("Error", erroMassage);
            }
        }
    }
}
