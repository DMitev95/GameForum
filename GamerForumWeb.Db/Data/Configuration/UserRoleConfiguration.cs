//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace GamerForumWeb.Db.Data.Configuration
//{
//    internal class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
//    {
//        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
//        {
//            builder.HasData(CreateUserRole());
//        }

//        private List<IdentityUserRole<string>> CreateUserRole()
//        {
//            var comments = new List<IdentityUserRole<string>>()
//            {
//                new IdentityUserRole<string>()
//                {
//                    UserId = "c080eac6-2f20-4f29-8717-d059c81f1195",
//                    RoleId = "1",
//                },
//            };
//            return comments;
//        }
//    }
//}
