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
        private readonly IPostService postService;

        public GameController(IGameService _gameService, IPostService postService)
        {
            gameService = _gameService;
            this.postService = postService;
        }

        [AllowAnonymous]
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


        public async Task<IActionResult> Delete(int id)
        {
           await gameService.DeleteGame(id);

            return RedirectToAction(nameof(All));
        }
    }
}
