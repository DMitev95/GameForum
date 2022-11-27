using GamerForumWeb.Core.Models.Game;
using GamerForumWeb.Core.Models.Users;
using GamerForumWeb.Db.Data.Entities;

namespace GamerForumWeb.Core.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<GamesQueryModel>> GetUserFavoriteGamesAsync(string userId);

        Task AddGameToUserCollectionAsync(int gameId, string userId);

        Task RemoveGameFromUserCollectionAsync(int gameId, string userId);

        Task<IEnumerable<UserQueryModel>> GetUsers();

        Task<UserEditModel> GetUserForEdit(string id);

        Task<bool> UpdateUser(UserEditModel model);

        Task<User> GetUserById(string id);

        Task<string> GetUserNameById(string id);
    }
}
