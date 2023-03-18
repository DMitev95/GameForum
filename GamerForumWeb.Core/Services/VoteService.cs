using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Db.Data.Entities;
using GamerForumWeb.Db.Repository;

namespace GamerForumWeb.Core.Services
{
    public class VoteService : IVoteService
    {
        private readonly IRepository repo;

        public VoteService(IRepository _repo)
        {
            repo = _repo;
        }

        public int GetVotes(int commentId)
        {
            var votes = this.repo.All<Vote>()
                .Where(x => x.CommentId == commentId).Sum(x => (int)x.Type);
            return votes;
        }

        public async Task<int> VoteAsync(int commentId, string userId, bool isUpVote)
        {
            var vote = repo.All<Vote>().FirstOrDefault(v => v.Comment.Id == commentId && v.UserId == userId);
            var comment = await repo.GetByIdAsync<PostComment>(commentId);
            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.Up : VoteType.Down;
            }
            else
            {
                vote = new Vote
                {
                    Comment = comment,
                    UserId = userId,
                    Type = isUpVote ? VoteType.Up : VoteType.Down,
                };

                await repo.AddAsync(vote);
            }

            await repo.SaveChangesAsync();
            return comment.PostId;
        }
    }
}
