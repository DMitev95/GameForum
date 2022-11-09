using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Game;
using GamerForumWeb.Db.Data;
using GamerForumWeb.Db.Data.Entities;
using GamerForumWeb.Db.Repository;
using Microsoft.EntityFrameworkCore;

namespace GamerForumWeb.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly GamerForumWebDbContext context;

        public UserService(IRepository _repo, GamerForumWebDbContext _context)
        {
            repo = _repo;
            context = _context;
        }

        public async Task<IEnumerable<GamesQueryModel>> GetUserFavoriteGamesAsync(string userId)
        {
            var user = await context.Users.Where(u => u.Id == userId)
                .Include(u => u.Games)
                .ThenInclude(ug => ug.Game)
                .ThenInclude(g => g.Category)
                .FirstOrDefaultAsync();
            if (user == null)
            {
                throw new ArgumentException("User dont exist!");
            }

            return user.Games.Select(u => new GamesQueryModel()
            {
                Id = u.GameId,
                Title = u.Game.Title,
                Studio = u.Game.Studio,
                Description = u.Game.Description,
                ImageUrl = u.Game.ImageUrl,
                Rating = u.Game.Rating,
                Category = u.Game.Category.Name
            });
        }

        public async Task AddGameToUserCollectionAsync(int gameId, string userId)
        {
            var user = await context.Users.Where(u => u.Id == userId).Include(u => u.Games).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new ArgumentException("Invalid User ID");
            }

            var game = await repo.GetByIdAsync<Game>(gameId);
            if (game == null)
            {
                throw new ArgumentException("Invalid Game ID");
            }

            if (!user.Games.Any(g => g.GameId == gameId))
            {
                user.Games.Add(new UserGames()
                {
                    GameId = game.Id,
                    UserId = user.Id,
                    Game = game,
                    User = user
                });
                await context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Game is already addent to favorite!");
            }
        }

        public async Task RemoveGameFromUserCollectionAsync(int gameId, string userId)
        {
            var user = await context.Users.Where(u => u.Id == userId).Include(u => u.Games).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user Id");
            }

            var game = user.Games.FirstOrDefault(b => b.GameId == gameId);

            if (game == null)
            {
                throw new ArgumentException("Invalid game Id");
            }
            user.Games.Remove(game);
            await context.SaveChangesAsync();
        }
    }
}
