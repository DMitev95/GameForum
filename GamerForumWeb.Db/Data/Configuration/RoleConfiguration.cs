using GamerForumWeb.Db.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamerForumWeb.Db.Data.Configuration
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(CreateUserRole());
        }

        private List<Role> CreateUserRole()
        {
            var comments = new List<Role>()
            {
                new Role()
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    CreatedOn = DateTime.Now,
                },
                new Role()
                {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER",
                    CreatedOn = DateTime.Now,
                },
            };
            return comments;
        }
    }
}
