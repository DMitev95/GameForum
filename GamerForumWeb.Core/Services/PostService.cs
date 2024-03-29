﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper mapper;

        public PostService(IRepository _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }

        public async Task AddPost(PostModel model, string userId)
        {
            var sanitizor = new HtmlSanitizer();

            var game = await repo.GetByIdAsync<Game>(model.GameId);
            if (game == null) throw new ArgumentException("Invalid game!");

            var user = await repo.All<User>(u => u.Id == userId, u => u.Posts).FirstOrDefaultAsync();
            if (user == null) throw new ArgumentException("Invalid user!");

            var post = mapper.Map<Post>(model);
            post.UserId = userId;
            post.CreatedDate = DateTime.Now;
            post.Title = sanitizor.Sanitize(post.Title);
            post.Content = sanitizor.Sanitize(post.Content);

            game?.Posts.Add(post);
            user?.Posts.Add(post);
            await repo.AddAsync(post);
            await repo.SaveChangesAsync();
        }

        public async Task<int> DeletePost(int postId)
        {
            var post = await repo.All<Post>().Where(p => p.Id == postId && p.IsDeleted == false).FirstOrDefaultAsync();
            if (post == null)
            {
                throw new ArgumentException("Invalid post!");
            }
            post.IsDeleted = true;
            post.DeletedOn= DateTime.Now;

            await repo.SaveChangesAsync();

            return post.GameId;
        }

        public async Task<IEnumerable<PostQueryModel>> GetAllGamePost(int gameId)
        {
            return await repo.AllReadonly<Post>().Where(p => p.GameId == gameId && p.IsDeleted == false).ProjectTo<PostQueryModel>(mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
