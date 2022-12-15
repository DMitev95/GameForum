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
                    Content = "I need Help please help me!",
                    PostId = 1,
                    UserId = "25a6dc8b-a212-4cd8-9b62-efcdea0c7ab1"
                }
            };
            return comments;
        }
    }
}
