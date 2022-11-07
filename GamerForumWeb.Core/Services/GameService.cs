using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Game;
using GamerForumWeb.Db.Data;
using GamerForumWeb.Db.Data.Entities;
using GamerForumWeb.Db.Repository;
using Microsoft.EntityFrameworkCore;

namespace GamerForumWeb.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IRepository repo;
        private readonly GamerForumWebDbContext context;

        public GameService(IRepository _repo, GamerForumWebDbContext _context)
        {
            repo = _repo;
            context = _context;
        }

        public async Task AddNewGame(GameModel model)
        {
            var game = new Game()
            {
                Title = model.Title,
                Studio = model.Studio,
                Description = model.Description,
                Rating = model.Rating,
                CreatedDate = DateTime.Now,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl,
            };
            await repo.AddAsync(game);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<GamesQueryModel>> AllGames()
        {
            return await repo.AllReadonly<Game>().Select(g => new GamesQueryModel()
            {
                Id = g.Id,
                ImageUrl = g.ImageUrl,
                Title = g.Title,
                Description = g.Description,
                Rating = g.Rating,
                Studio = g.Studio,
                Category = g.Category.Name

            }).ToListAsync();
        }

        public async Task DeleteGame(int id)
        {
            await repo.DeleteAsync<Game>(id);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<GameModel> GetGameModelById(int gameId)
        {
            var game =  await repo.GetByIdAsync<Game>(gameId);
            if (game == null)
            {
                throw new ArgumentException("Invalid game Id!");
            }

            return new GameModel()
            {
                Title = game.Title,
                Description = game.Description,
                Studio = game.Studio,
                Rating = game.Rating,
                CategoryId = game.CategoryId,
                ImageUrl = game.ImageUrl,
                Categories = context.Categories.ToList(),
            };
        }

        public async Task<IEnumerable<GamesQueryModel>> GetGamesByCategory(int categoryId)
        {
            return await context.Games.Where(g => g.CategoryId == categoryId).Select(g => new GamesQueryModel()
            {
                Id = g.Id,
                Title = g.Title,
                Studio = g.Studio,
                Description = g.Description,
                Rating = g.Rating,
                ImageUrl = g.ImageUrl,
                Category = g.Category.Name
            }).ToListAsync();
        }

        public async Task<IEnumerable<GamesQueryModel>> GetTopGames()
        {
            return await repo.AllReadonly<Game>()
                .OrderBy(g => g.Rating)
                .Select(g => new GamesQueryModel()
                {
                    Id = g.Id,
                    ImageUrl = g.ImageUrl,
                    Title = g.Title,
                    Description = g.Description,
                    Rating = g.Rating,
                    Studio = g.Studio,
                    Category = g.Category.Name
                })
                .Take(3)
                .ToListAsync();
        }      

        public async Task UpdateGame(int gameId, GameModel model)
        {
            var game = await repo.GetByIdAsync<Game>(gameId);
            if (game == null)
            {
                throw new ArgumentException("Invalid game ID");
            }
            game.Title = model.Title;
            game.Description = model.Description;
            game.Studio = model.Studio;
            game.Rating = model.Rating;
            game.CategoryId = model.CategoryId; 
            game.ImageUrl = model.ImageUrl;
            game.ModifiedOn = DateTime.Now;

            repo.Update(game);
           await repo.SaveChangesAsync();
        }
    }
}
