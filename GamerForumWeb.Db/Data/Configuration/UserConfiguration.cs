using GamerForumWeb.Db.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamerForumWeb.Db.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(CreateUser());

        }

        PasswordHasher<User> hasher = new PasswordHasher<User>();

        private User CreateUser()
        {
            var user = new User()
            {
                Id = "25a6dc8b-a212-4cd8-9b62-efcdea0c7ab1",
                UserName = "Admin",
                Email = "admin@gmail.bg",
                FirstName = "Admin",
                LastName = "Admin",                
            };
            user.PasswordHash = hasher.HashPassword(user, "Admin1234");
            return user;
        }
    }
}
