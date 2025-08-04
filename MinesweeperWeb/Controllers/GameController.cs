using Microsoft.AspNetCore.Mvc;
using Minesweeper.BLL.DTO_s;
using Minesweeper.BLL.Logic.Minesweeper.BLL.Logic;
using Minesweeper.BLL.Services.Interface;

namespace MinesweeperWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("start")]
        public async Task<ActionResult<FieldDto>> StartGame([FromQuery] string playerName)
        {
            var field = await _gameService.CreateGameAsync(10, 10, 10, playerName);
            return Ok(field);
        }

        [HttpPost("{gameId}/open")]
        public async Task<ActionResult<FieldDto>> OpenCell(Guid gameId, [FromQuery] int x, [FromQuery] int y)
        {
            var field = await _gameService.OpenCellAsync(gameId, x, y);
            return Ok(field);
        }

        [HttpPost("{gameId}/flag")]
        public async Task<ActionResult<FieldDto>> ToggleFlag(Guid gameId, [FromQuery] int x, [FromQuery] int y)
        {
            var field = await _gameService.ToggleFlagAsync(gameId, x, y);
            return Ok(field);
        }

        [HttpGet("{gameId}")]
        public async Task<ActionResult<FieldDto>> GetGameField(Guid gameId)
        {
            var field = await _gameService.GetGameFieldAsync(gameId);
            return Ok(field);
        }

       
    }
}
