using AutoMapper;
using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Comment;
using GamerForumWeb.Core.Models.Post;
using GamerForumWeb.Db.Data.Entities;
using GamerForumWeb.Db.Repository;
using Microsoft.EntityFrameworkCore;

namespace GamerForumWeb.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repo;
        private readonly IMapper mapper;

        public CommentService(IRepository _repo, IMapper _mapper)
        {
            this.repo = _repo;
            this.mapper = _mapper;
        }

        public async Task AddComment(CommentModel model, string userId)
        {
            var post = await repo.GetByIdAsync<Post>(model.PostId);

            if (post == null)
            {
                throw new ArgumentException("Invalid post!");
            }

            var user = await repo.GetByIdAsync<User>(userId);

            if (user == null)
            {
                throw new ArgumentException("Invalid user!");
            }

            var comment = mapper.Map<PostComment>(model);
            comment.UserId = userId;
         
            post?.Comments.Add(comment);
            user?.Comments.Add(comment);
            await repo.AddAsync(comment);
            await repo.SaveChangesAsync();
        }

        public async Task<PostQueryModel> AllComments(int postId)
        {
            var p = await repo.All<Post>().Where(p => p.Id == postId)
               .Include(pc => pc.Comments.Where(x=>x.IsDeleted == false))
               .ThenInclude(v => v.Votes)
               .FirstOrDefaultAsync();
            

            if (p == null)
            {
                throw new ArgumentException("Invalid post!");
            }
            var user = await repo.GetByIdAsync<User>(p.UserId);

            var allComents = mapper.Map<PostQueryModel>(p);
            allComents.PostId = p.Id;
            allComents.Username = user.UserName;
            return allComents;
        }

        public async Task<int> DeleteComment(int commentId)
        {
            var comment = await repo.GetByIdAsync<PostComment>(commentId);
            if (comment == null)
            {
                throw new ArgumentException("Invalid comment!");
            }
            comment.IsDeleted= true;
            comment.DeletedOn = DateTime.Now;
            repo.Update(comment);
            await repo.SaveChangesAsync();
            return comment.PostId;
        }

        public async Task<CommentModel> GetCommentById(int commentId)
        {
            var comment = await repo.GetByIdAsync<PostComment>(commentId);
            if (comment == null)
            {
                throw new ArgumentException("Invalid comment!");
            }
             var commentModel = mapper.Map<CommentModel>(comment);
            return commentModel;
        }

        public async Task<int> UpdateComment(int commentId, CommentModel model)
        {
            var comment = await repo.GetByIdAsync<PostComment>(commentId);
            if (comment == null)
            {
                throw new ArgumentException("Invalid comment!");
            }
            comment.Content = model.Content;
            comment.UpdatedDate = DateTime.Now;

            repo.Update(comment);
            await repo.SaveChangesAsync();

            return comment.PostId;
        }
    }
}
