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
                    UserId = "c080eac6-2f20-4f29-8717-d059c81f1195",
                    GameId = 1,
                }
            };
            return comments;
        }
    }
}
