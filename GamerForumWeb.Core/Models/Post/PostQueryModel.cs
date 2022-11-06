

namespace GamerForumWeb.Core.Models.Post
{
    public class PostQueryModel
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int GameId { get; set; }
        public string Username { get; set; }

        public string UserId { get; set; } = null!;
    }
}
