using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Comment;
using GamerForumWeb.Core.Models.Post;
using GamerForumWeb.Db.Data.Entities;
using GamerForumWeb.Db.Repository;
using Ganss.Xss;
using Microsoft.EntityFrameworkCore;

namespace GamerForumWeb.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repo;

        public CommentService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task AddComment(CommentModel model, string userId)
        {
            var sanitizor = new HtmlSanitizer();

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

            var comment = new PostComment()
            {
                Content = sanitizor.Sanitize(model.Content),
                UserId = userId,
                CreatedDate = DateTime.Now,
                PostId = model.PostId,
            };

            post?.Comments.Add(comment);
            user?.Comments.Add(comment);
            await repo.AddAsync(comment);
            await repo.SaveChangesAsync();
        }

        public async Task<PostQueryModel> AllComments(int postId)
        {
            var p = await repo.All<Post>().Where(p => p.Id == postId)
               .Include(pc => pc.Comments)
               .ThenInclude(v => v.Votes)
               .FirstOrDefaultAsync();
            

            if (p == null)
            {
                throw new ArgumentException("Invalid post!");
            }
            var user = await repo.GetByIdAsync<User>(p.UserId);

            var allComents = new PostQueryModel()
            {
                PostId = p.Id,
                Title = p.Title,
                Content = p.Content,
                UserId = p.UserId,
                Username = user.UserName,
                CreatedOn = p.CreatedDate,
                Comments = p.Comments
            };
            return allComents;
        }

        public async Task<int> DeleteComment(int commentId)
        {
            var comment = await repo.GetByIdAsync<PostComment>(commentId);
            if (comment == null)
            {
                throw new ArgumentException("Invalid comment!");
            }

            var vote = await repo.All<Vote>(v=>v.Comment.Id == commentId).ToListAsync();
            if (vote != null)
            {
                foreach (var item in vote)
                {
                    await repo.DeleteAsync<Vote>(item.Id);
                    
                }
                await repo.SaveChangesAsync();
            }
            await repo.DeleteAsync<PostComment>(commentId);
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

            return new CommentModel()
            {
                Content = comment.Content,
            };
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
