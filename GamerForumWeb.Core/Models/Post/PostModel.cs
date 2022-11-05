

namespace GamerForumWeb.Core.Models.Post
{
    public class PostModel
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int GameId { get; set; }
    }
}
