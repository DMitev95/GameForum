using GamerForumWeb.Db.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamerForumWeb.Db.Data.Configuration
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(CreatePost());
        }

        private List<Post> CreatePost()
        {
            var posts = new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Title = "I got stuck in Northrend! Help me plox!!!",
                    Content = "I am on quest to kill some frogs and one is missing?!",
                    GameId = 1,
                    UserId = "25a6dc8b-a212-4cd8-9b62-efcdea0c7ab1"
                }
            };
            return posts;
        }
    }
}
