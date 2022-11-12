using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GamerForumWeb.Areas.Users.Controllers
{
    [Area("Users")]
    public class HomeController : Controller
    {
        private readonly IGameService gameService;

        public HomeController(IGameService _gameService)
        {
            gameService = _gameService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await gameService.GetTopGames();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}