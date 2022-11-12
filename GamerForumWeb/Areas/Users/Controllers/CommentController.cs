using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Comment;
using GamerForumWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamerForumWeb.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IVoteService votesService;

        public CommentController(ICommentService _commentService, IVoteService _votesService)
        {
            commentService = _commentService;
            votesService = _votesService;
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
            var postId = await commentService.DeleteComment(commentId);

            return RedirectToAction("All", new { id = postId });
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
                var postId = await commentService.UpdateComment(commentId, model);

                return RedirectToAction("All", new { id = postId });
            }
            catch (Exception e)
            {
                var erroMassage = new ErrorViewModel { RequestId = e.Message };
                return View("Error", erroMassage);
            }
        }

        public async Task<IActionResult> Like(int commentId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var postId = await votesService.VoteAsync(commentId, userId, true);
            return RedirectToAction("All", new { id = postId });
        }

        public async Task<IActionResult> Dislike(int commentId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var postId = await votesService.VoteAsync(commentId, userId, false);
            return RedirectToAction("All", new { id = postId });
        }
    }
}
