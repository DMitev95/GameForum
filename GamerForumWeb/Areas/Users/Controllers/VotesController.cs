using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Vote;
using GamerForumWeb.Db.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GamerForumWeb.Areas.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly IVoteService votesService;
        private readonly UserManager<User> userManager;

        public VotesController(
            IVoteService _votesService,
            UserManager<User> _userManager)
        {
            this.votesService = _votesService;
            this.userManager = _userManager;
        }

        // POST /api/votes
        // Request body: {"postId":1,"isUpVote":true}
        // Response body: {"votesCount":16}
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteCountModel>> Post(VoteCreateModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.votesService.VoteAsync(input.CommentId, userId, input.IsUpVote);
            var votes = this.votesService.GetVotes(input.CommentId);
            return new VoteCountModel { VotesCount = votes };
        }
    }
}
