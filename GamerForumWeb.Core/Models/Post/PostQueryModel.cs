using GamerForumWeb.Core.Models.Comment;
using GamerForumWeb.Db.Data.Entities;

namespace GamerForumWeb.Core.Models.Post
{
    public class PostQueryModel
    {
        public int PostId { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? GameId { get; set; }

        public string? Username { get; set; }

        //public int VotesCount { get; set; }

        public List<CommentQueryModel> Comments { get; set; } = new List<CommentQueryModel>();

        public string? UserId { get; set; }
    }
}
