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
                    UserId = "25a6dc8b-a212-4cd8-9b62-efcdea0c7ab1",
                    GameId = 1,
                }
            };
            return comments;
        }
    }
}
