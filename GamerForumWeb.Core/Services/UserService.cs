using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Game;
using GamerForumWeb.Core.Models.Users;
using GamerForumWeb.Db.Data.Entities;
using GamerForumWeb.Db.Repository;
using Microsoft.EntityFrameworkCore;

namespace GamerForumWeb.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<GamesQueryModel>> GetUserFavoriteGamesAsync(string userId)
        {
            var user = await repo.All<User>().Where(u => u.Id == userId)
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
            var user = await repo.All<User>(u => u.Id == userId, u => u.Games).FirstOrDefaultAsync();
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
                await repo.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Game is already addent to favorite!");
            }
        }

        public async Task RemoveGameFromUserCollectionAsync(int gameId, string userId)
        {
            var user = await repo.All<User>(u => u.Id == userId, u => u.Games).FirstOrDefaultAsync();

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
            await repo.SaveChangesAsync();
        }
        public async Task<User> GetUserById(string id)
        {
            return await repo.GetByIdAsync<User>(id);
        }

        public async Task<UserEditModel> GetUserForEdit(string id)
        {
            var user = await repo.GetByIdAsync<User>(id);

            return new UserEditModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<IEnumerable<UserQueryModel>> GetUsers()
        {
            return await repo.All<User>()
                .Select(u => new UserQueryModel()
                {
                    Email = u.Email,
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateUser(UserEditModel model)
        {
            bool result = false;
            var user = await repo.GetByIdAsync<User>(model.Id);

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }
    }
}
