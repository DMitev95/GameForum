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
                    Content = "I am on quest to kill some dogshit frogs and one is missing?!",
                    GameId = 1,
                    UserId = "c080eac6-2f20-4f29-8717-d059c81f1195"
                }
            };
            return posts;
        }
    }
}
