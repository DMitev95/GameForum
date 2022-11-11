using GamerForumWeb.Core.Models.Post;

namespace GamerForumWeb.Core.Contracts
{
    public interface IPostService
    {
        Task<IEnumerable<PostQueryModel>> GetAllGamePost(int gameId);
        Task AddPost(PostModel model, string userId);

        Task<int> DeletePost(int postId);
    }
}
