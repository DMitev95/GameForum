using Microsoft.AspNetCore.Mvc;
using GamerForumWeb.Core.Models.Game;
using Microsoft.AspNetCore.Authorization;
using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Models;
using Microsoft.Extensions.Caching.Memory;

namespace GamerForumWeb.Areas.Admin.Controllers
{
    [Area("Users")]
    [Authorize]
    public class UserGameController : Controller
    {
        private readonly IGameService gameService;

        public UserGameController(IGameService _gameService)
        {
            this.gameService = _gameService;
        }

        public async Task<IActionResult> All()
        {
            var model = await gameService.AllGames();

            return View(model);
        }

        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var model = await gameService.GetGamesByCategory(categoryId);
            return View(model);
        }

        public async Task<IActionResult> FindeByName(string id)
        {
            try
            {
                var model = await gameService.FindeGameByName(id);

                return View(model);
            }
            catch (Exception e)
            {
                var erroMassage = new ErrorViewModel { RequestId = e.Message };
                return View("Error", erroMassage);
            }
        }
    }
}
