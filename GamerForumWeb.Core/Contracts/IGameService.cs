using GamerForumWeb.Core.Models.Game;
using GamerForumWeb.Db.Data.Entities;

namespace GamerForumWeb.Core.Contracts
{
    public interface IGameService
    {
        Task<IEnumerable<GamesQueryModel>> AllGames();
        Task<IEnumerable<GamesQueryModel>> GetTopGames();
        Task<GameModel> GetGameModelById(int gameId);
        Task AddNewGame(GameModel model);
        Task<IEnumerable<Category>> GetCategories();
        Task DeleteGame(int id);
        Task UpdateGame(int gameId, GameModel model);

    }
}
