using GamerForumWeb.Core.Models.Comment;
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

        Task<IEnumerable<CommentQueryModel>> AllComments(int postId);

        Task DeleteComment(int commentId);
    }
}
