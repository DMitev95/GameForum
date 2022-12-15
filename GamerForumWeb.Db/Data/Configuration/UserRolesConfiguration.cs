using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamerForumWeb.Db.Data.Configuration
{
    internal class UserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(CreateUserRoles());
        }

        private IdentityUserRole<string> CreateUserRoles()
        {
            var user = new IdentityUserRole<string>()
            {
                RoleId = "1",
                UserId = "25a6dc8b-a212-4cd8-9b62-efcdea0c7ab1"
            };
            return user;
        }
    }
}
