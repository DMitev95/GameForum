using GamerForumWeb.Db.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamerForumWeb.Db.Data.Configuration
{
    internal class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasData(CreateGames());
        }

        private List<Game> CreateGames()
        {
            List<Game> games = new List<Game>()
            {
                new Game
                {
                    Id = 1,
                    Title = "World of Warcraft",
                    Studio = "Blizzrd",
                    CategoryId = 5,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/6/65/World_of_Warcraft.png",
                    Description = "Dog shit game!!!",
                    Rating = 6,
                    
                },
                new Game
                {
                    Id = 2,
                    Title = "Minecraft",
                    Studio = "Mojang",
                    CategoryId = 1,
                    ImageUrl = "https://www.minecraft.net/content/dam/games/minecraft/key-art/CC-Update-Part-II_600x360.jpg",
                    Description = "Great game",
                    Rating = 10,

                },
            };
            
            return games;
        }
    }
}
