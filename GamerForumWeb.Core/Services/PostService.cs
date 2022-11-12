﻿using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Post;
using GamerForumWeb.Db.Data;
using GamerForumWeb.Db.Data.Entities;
using GamerForumWeb.Db.Repository;
using Ganss.Xss;
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
            var sanitizor = new HtmlSanitizer();
            var game = await dbContext.Games.FirstOrDefaultAsync(g=>g.Id == model.GameId);
            if (game == null) throw new ArgumentException("Invalid game!");

            var user = await dbContext.Users.Where(u => u.Id == userId).Include(u => u.Posts).FirstOrDefaultAsync();
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
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();

        }

        public async Task<int> DeletePost(int postId)
        {
            var post = await repo.GetByIdAsync<Post>(postId);
            if (post == null)
            {
                throw new ArgumentException("Invalid post!");
            }
            await repo.DeleteAsync<Post>(postId);
            await repo.SaveChangesAsync();

            return post.GameId;
        }

        public async Task<IEnumerable<PostQueryModel>> GetAllGamePost(int gameId)
        {
            return await repo.AllReadonly<Post>().Where(p=>p.GameId == gameId).Select(p => new PostQueryModel()
            {
                PostId = p.Id,
                Title = p.Title,
                Content = p.Content,
                CreatedOn = p.CreatedDate,
                GameId = gameId,
                Username = p.User.UserName
            }).ToListAsync();
        }
    }
}
