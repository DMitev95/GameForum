using GamerForumWeb.Db.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamerForumWeb.Db.Data.Configuration
{
    internal class PostComentConfiguration : IEntityTypeConfiguration<PostComment>
    {
        public void Configure(EntityTypeBuilder<PostComment> builder)
        {
            builder.HasData(CreateComment());
        }
        private List<PostComment> CreateComment()
        {
            var comments = new List<PostComment>()
            {
                new PostComment
                {
                    Id = 1,
                    Content = "You suck, go fuck yoursef!!!",
                    PostId = 1,
                    UserId = "06df5d6a-ae43-4a1e-a3ad-0c9f6ddf777c"
                }
            };
            return comments;
        }
    }
}
