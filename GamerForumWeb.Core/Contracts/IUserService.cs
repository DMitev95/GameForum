using GamerForumWeb.Core.Models.Game;

namespace GamerForumWeb.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<GamesQueryModel>> GetUserFavoriteGamesAsync(string userId);

        Task AddGameToUserCollectionAsync(int gameId, string userId);

        Task RemoveGameFromUserCollectionAsync(int gameId, string userId);
    }
}
