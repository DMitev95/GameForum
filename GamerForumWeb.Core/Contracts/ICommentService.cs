using GamerForumWeb.Core.Models.Comment;
using GamerForumWeb.Core.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerForumWeb.Core.Contracts
{
    public interface ICommentService
    {
        Task AddComment(CommentModel model, string userId);

        Task<PostQueryModel> AllComments(int postId);

        Task<int> DeleteComment(int commentId);
        Task<CommentModel> GetCommentById(int commentId);

        Task<int> UpdateComment(int commentId, CommentModel model);
    }
}
