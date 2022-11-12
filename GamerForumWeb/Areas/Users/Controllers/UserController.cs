using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamerForumWeb.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        public async Task<IActionResult> AddToCollection(int gameId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await userService.AddGameToUserCollectionAsync(gameId, userId);
            }
            catch (Exception e)
            {
                var erroMassage = new ErrorViewModel { RequestId = e.Message };
                return View("Error", erroMassage);
            }

            return RedirectToAction(nameof(MyFavoriteGames));
        }

        public async Task<IActionResult> MyFavoriteGames()
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var model = await userService.GetUserFavoriteGamesAsync(userId);

                return View("My", model);
            }
            catch (Exception e)
            {
                var errorMassage = new ErrorViewModel { RequestId = e.Message };
                return View("Error", errorMassage);
            }
        }

        public async Task<IActionResult> RemoveFromCollection(int gameId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await userService.RemoveGameFromUserCollectionAsync(gameId, userId);
                return RedirectToAction(nameof(MyFavoriteGames));
            }
            catch (Exception e)
            {
                var errorMassage = new ErrorViewModel { RequestId = e.Message };
                return View("Error", errorMassage);
            }

        }
    }
}
