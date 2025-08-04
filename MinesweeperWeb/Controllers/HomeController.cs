using Microsoft.AspNetCore.Mvc;
using Minesweeper.BLL.Services.Interface;
using MinesweeperWeb.ViewModels;

namespace MinesweeperWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IGameResultService _gameResultService;

        public HomeController(IGameResultService gameResultService, IGameService gameService)
        {
            _gameResultService = gameResultService;
            _gameService = gameService;
        }

        public async Task<IActionResult> Rating()
        {
            var topResults = await _gameResultService.GetTopResultsAsync(10);

            var model = topResults.Select(r => new GameResultViewModel
            {
                PlayerName = r.PlayerName,
                TimeTaken = r.TimeTaken,
                IsWin = r.IsWin,
                DatePlayed = r.DatePlayed
            }).ToList();

            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Start(string playerName = "Player")
        {
            var fieldDto = await _gameService.CreateGameAsync(10, 10, 10, playerName);
            return View("Game", fieldDto);
        }



    }

}
