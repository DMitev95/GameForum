namespace GamerForumWeb.Core.Contracts
{
    public interface IVoteService
    {
        Task<int> VoteAsync(int commentId, string userId, bool isUpVote);
    }
}
