using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Post;
using GamerForumWeb.Db.Data.Entities;
using GamerForumWeb.Db.Repository;
using Ganss.Xss;
using Microsoft.EntityFrameworkCore;

namespace GamerForumWeb.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository repo;

        public PostService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddPost(PostModel model, string userId)
        {
            var sanitizor = new HtmlSanitizer();

            var game = await repo.GetByIdAsync<Game>(model.GameId);
            if (game == null) throw new ArgumentException("Invalid game!");

            var user = await repo.All<User>(u => u.Id == userId, u => u.Posts).FirstOrDefaultAsync();
            if (user == null) throw new ArgumentException("Invalid user!");

            var post = new Post()
            {
                Title = sanitizor.Sanitize(model.Title),
                Content = sanitizor.Sanitize(model.Content),
                CreatedDate = DateTime.Now,
                UserId = userId,
                GameId = model.GameId
            };
            game?.Posts.Add(post);
            user?.Posts.Add(post);
            await repo.AddAsync(post);
            await repo.SaveChangesAsync();

        }

        public async Task<int> DeletePost(int postId)
        {
            var post = await repo.All<Post>().Where(p => p.Id == postId)
               .Include(pc => pc.Comments)
               .ThenInclude(v => v.Votes)
               .FirstOrDefaultAsync();
            if (post == null)
            {
                throw new ArgumentException("Invalid post!");
            }
            foreach (var comment in post.Comments)
            {
                foreach (var vote in comment.Votes)
                {
                    await repo.DeleteAsync<Vote>(vote.Id);
                    
                }
                await repo.SaveChangesAsync();
                await repo.DeleteAsync<PostComment>(comment.Id);
            }
            await repo.SaveChangesAsync();
            await repo.DeleteAsync<Post>(postId);
            await repo.SaveChangesAsync();

            return post.GameId;
        }

        public async Task<IEnumerable<PostQueryModel>> GetAllGamePost(int gameId)
        {
            return await repo.AllReadonly<Post>().Where(p => p.GameId == gameId).Select(p => new PostQueryModel()
            {
                PostId = p.Id,
                Title = p.Title,
                Content = p.Content,
                CreatedOn = p.CreatedDate,
                GameId = gameId,
                UserId = p.UserId,
                Username = p.User.UserName
            }).ToListAsync();
        }
    }
}
