using AutoMapper;
using AutoMapper.QueryableExtensions;
using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Game;
using GamerForumWeb.Db.Data.Entities;
using GamerForumWeb.Db.Repository;
using Ganss.Xss;
using Microsoft.EntityFrameworkCore;

namespace GamerForumWeb.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IRepository repo;
        private readonly IMapper mapper;

        public GameService(IRepository _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }

        public async Task AddNewGame(GameModel model)
        {
            var sanitizor = new HtmlSanitizer();
            var game = mapper.Map<Game>(model);

            game.Title = sanitizor.Sanitize(game.Title);
            game.Studio = sanitizor.Sanitize(game.Studio);
            game.Description = sanitizor.Sanitize(game.Description);
            game.ImageUrl = sanitizor.Sanitize(game.ImageUrl);

            await repo.AddAsync(game);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<GamesQueryModel>> AllGames()
        {
            return await repo.AllReadonly<Game>().Where(g=>g.IsDeleted == false).OrderByDescending(g => g.Rating).ThenByDescending(g => g.Title)
                .ProjectTo<GamesQueryModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task DeleteGame(int id)
        {
            var game = await repo.All<Game>().Where(g => g.Id == id).FirstOrDefaultAsync();

            if (game == null || game.IsDeleted == true)
            {
                throw new ArgumentException("Invalid Game!");
            }
            game.IsDeleted= true;
            game.DeletedOn = DateTime.Now;
            repo.Update(game);
            await repo.SaveChangesAsync();
        }

        public async Task<GamesQueryModel> FindeGameByName(string gameName)
        {
            var game = await repo.All<Game>(g => g.Title == gameName && g.IsDeleted == false).FirstOrDefaultAsync();
            if (game == null)
            {
                throw new ArgumentException("Invalid game name!");
            }

            var category = await repo.GetByIdAsync<Category>(game.CategoryId);
            var gameModel = mapper.Map<GamesQueryModel>(game);
            gameModel.CategoryName = category.Name;

            return gameModel;  
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await repo.All<Category>().ToListAsync();
        }

        public async Task<GameModel> GetGameModelById(int gameId)
        {
            var game =  await repo.GetByIdAsync<Game>(gameId);

            if (game == null || game.IsDeleted == true)
            {
                throw new ArgumentException("Invalid game Id!");
            }

            var gameModel = mapper.Map<GameModel>(game);
            gameModel.Categories = repo.All<Category>();

            return gameModel;
        }

        public async Task<IEnumerable<GamesQueryModel>> GetGamesByCategory(int categoryId)
        {
            return await repo.All<Game>(g => g.CategoryId == categoryId && g.IsDeleted == false)
                .ProjectTo<GamesQueryModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<GamesQueryModel>> GetTopGames()
        {
            return await repo.AllReadonly<Game>()
                .OrderByDescending(g => g.Rating)
                .ProjectTo<GamesQueryModel>(mapper.ConfigurationProvider)
                .Take(3)
                .ToListAsync();
        }      

        public async Task UpdateGame(int gameId, GameModel model)
        {
            var sanitizor = new HtmlSanitizer();
            var game = await repo.GetByIdAsync<Game>(gameId);
            if (game == null)
            {
                throw new ArgumentException("Invalid game ID");
            }
            game.Title = sanitizor.Sanitize(model.Title);
            game.Description = sanitizor.Sanitize(model.Description);
            game.Studio = sanitizor.Sanitize(model.Studio);
            game.Rating = model.Rating;
            game.CategoryId = model.CategoryId; 
            game.ImageUrl = sanitizor.Sanitize(model.ImageUrl);
            game.ModifiedOn = DateTime.Now;

            repo.Update(game);
            await repo.SaveChangesAsync();
        }
    }
}
