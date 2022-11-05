using GamerForumWeb.Core.Models.Post;

namespace GamerForumWeb.Core.Contracts
{
    public interface IPostService
    {
        Task<IEnumerable<PostModel>> GetAllGamePost(int gameId);
        Task AddPost(PostModel model, string userId);
    }
}
