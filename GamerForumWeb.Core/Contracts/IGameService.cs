using GamerForumWeb.Core.Models.Game;
using GamerForumWeb.Db.Data.Entities;

namespace GamerForumWeb.Core.Contracts
{
    public interface IGameService
    {
        Task<IEnumerable<GamesQueryModel>> AllGames();
        Task<IEnumerable<GamesQueryModel>> GetTopGames();
        Task<IEnumerable<GamesQueryModel>> GetGameById(int gameId);
        Task AddNewGame(GameModel model);
        Task<IEnumerable<Category>> GetCategories();
        Task DeleteGame(int id);

    }
}
