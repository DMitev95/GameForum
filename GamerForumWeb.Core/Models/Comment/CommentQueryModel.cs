namespace GamerForumWeb.Core.Models.Comment
{
    public class CommentQueryModel
    {
        public int Id { get; set; } 

        public string Content { get; set; }

        public int Likes { get; set; }

        public string Username { get; set; }

        public DateTime CreatedDate { get; set; }

        public int PostId { get; set; }

        public string UserId { get; set; } = null!;
    }
}
