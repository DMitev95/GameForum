using GamerForumWeb.Db.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamerForumWeb.Db.Data.Configuration
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(CreateUserRole());
        }

        private List<UserRole> CreateUserRole()
        {
            var comments = new List<UserRole>()
            {
                new UserRole()
                {
                    UserId = "c080eac6-2f20-4f29-8717-d059c81f1195",
                    RoleId = "1",
                },
            };
            return comments;
        }
    }
}
