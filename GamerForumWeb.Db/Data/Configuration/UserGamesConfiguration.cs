using GamerForumWeb.Db.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamerForumWeb.Db.Data.Configuration
{
    internal class UserGamesConfiguration : IEntityTypeConfiguration<UserGames>
    {
        public void Configure(EntityTypeBuilder<UserGames> builder)
        {
            builder.HasData(CreateUserGame());
        }
        private List<UserGames> CreateUserGame()
        {
            var comments = new List<UserGames>()
            {
                new UserGames
                {                   
                    UserId = "06df5d6a-ae43-4a1e-a3ad-0c9f6ddf777c",
                    GameId = 1,
                }
            };
            return comments;
        }
    }
}
