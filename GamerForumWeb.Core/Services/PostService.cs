using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Post;
using GamerForumWeb.Db.Data;
using GamerForumWeb.Db.Data.Entities;
using GamerForumWeb.Db.Repository;
using Microsoft.EntityFrameworkCore;

namespace GamerForumWeb.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository repo;
        private readonly GamerForumWebDbContext dbContext;

        public PostService(IRepository _repo, GamerForumWebDbContext _dbContext)
        {
            repo = _repo;
            dbContext = _dbContext;
        }

        public async Task AddPost(PostModel model, string userId)
        {
            var game = await dbContext.Games.FirstOrDefaultAsync(g=>g.Id == model.GameId);
            var user = await dbContext.Users.Where(u => u.Id == userId).Include(u => u.Posts).FirstOrDefaultAsync();
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content,
                CreatedDate = DateTime.Now,
                UserId = userId,
                GameId = model.GameId
            };
            game.Posts.Add(post);
            user.Posts.Add(post);
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<PostModel>> GetAllGamePost(int gameId)
        {
            return await repo.AllReadonly<Post>().Where(p=>p.GameId == gameId).Select(p => new PostModel()
            {
                PostId = p.Id,
                Title = p.Title,
                Content = p.Content,
                CreatedOn = p.CreatedDate,
                GameId = gameId
            }).ToListAsync();
        }
    }
}
