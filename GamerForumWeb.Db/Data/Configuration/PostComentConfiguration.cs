using GamerForumWeb.Db.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    UserId = "c080eac6-2f20-4f29-8717-d059c81f1195"
                }
            };
            return comments;
        }
    }
}
