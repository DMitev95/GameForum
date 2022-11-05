using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Game;
using GamerForumWeb.Db.Data;
using GamerForumWeb.Db.Data.Entities;
using GamerForumWeb.Db.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<GamesQueryModel>> GetGameById(int gameId)
        {
            return (IEnumerable<GamesQueryModel>)await repo.GetByIdAsync<Game>(gameId);
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
    }
}
