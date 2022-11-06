using Microsoft.AspNetCore.Mvc;
using GamerForumWeb.Core.Models.Game;
using Microsoft.AspNetCore.Authorization;
using GamerForumWeb.Core.Contracts;

namespace GamerForumWeb.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IGameService gameService;

        public GameController(IGameService _gameService)
        {
            gameService = _gameService;
        }

        public async Task<IActionResult> All()
        {
            var model = await gameService.AllGames();

            return View(model);
        }
        

        public async Task<IActionResult> Mine()
        {
            var model = new GamesQueryModel();

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new GameModel()
            { 
                Categories = await gameService.GetCategories(),
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(GameModel model)
        {
            await gameService.AddNewGame(model);

            return RedirectToAction(nameof(All));
        }


        public async Task<IActionResult> Delete(int gameId)
        {
           await gameService.DeleteGame(gameId);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int gameId)
        {
            var game = await gameService.GetGameModelById(gameId);

            return View(game);            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int gameId, GameModel model)
        {
           await gameService.UpdateGame(gameId, model);

            return RedirectToAction(nameof(All));
        }
    }
}
