using GamerForumWeb.Db.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamerForumWeb.Db.Data.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            List<Category> categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Sandbox"
                },
                new Category
                {
                    Id = 2,
                    Name = "Real-time strategy (RTS)"
                },
                new Category
                {
                    Id = 3,
                    Name = "Real-time strategy (RTS)"
                },
                new Category
                {
                    Id = 4,
                    Name = "Multiplayer online battle arena (MOBA)"
                },
                new Category
                {
                    Id = 5,
                    Name = "Role-playing (RPG, ARPG, and More)"
                },
                new Category
                {
                    Id = 6,
                    Name = "Simulation and sports"
                },
                new Category
                {
                    Id = 7,
                    Name = "Puzzlers and party games"
                },
                new Category
                {
                    Id = 8,
                    Name = "Action-adventure"
                },
                new Category
                {
                    Id = 9,
                    Name = "Survival and horror"
                },
                new Category
                {
                    Id = 10,
                    Name = "Platformer"
                }
            };

            return categories;
        }
    }
}
