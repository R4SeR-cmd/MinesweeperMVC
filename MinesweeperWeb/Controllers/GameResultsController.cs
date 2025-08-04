using Microsoft.AspNetCore.Mvc;
using Minesweeper.BLL.DTO_s;
using Minesweeper.BLL.Services.Interface;
using Minesweeper.DAL.Entity;

namespace MinesweeperWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameResultController : ControllerBase
    {
        private readonly IGameResultService _gameResultService;

        public GameResultController(IGameResultService gameResultService)
        {
            _gameResultService = gameResultService;
        }

        // GET: api/GameResult/top/10
        [HttpGet("top/{count}")]
        public async Task<IActionResult> GetTopResults(int count)
        {
            var results = await _gameResultService.GetTopResultsAsync(count);

            var dtoList = results.Select(r => new GameResultViewDto
            {
                PlayerName = r.PlayerName,
                TimeTaken = r.TimeTaken,
                DatePlayed = r.DatePlayed
            }).ToList();

            return Ok(dtoList);
        }

        // POST: api/GameResult
        [HttpPost]
        public async Task<IActionResult> PostGameResult([FromBody] GameResultDto resultDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = new GameResult
            {
                PlayerName = resultDto.PlayerName,
                TimeTaken = resultDto.TimeTaken,
                IsWin = resultDto.IsWin,
                DatePlayed = DateTime.UtcNow
            };

            await _gameResultService.AddGameResultAsync(result);
            return Ok();
        }
    }

}

