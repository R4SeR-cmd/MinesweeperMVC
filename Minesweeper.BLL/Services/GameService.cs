using Minesweeper.BLL.DTO_s;
using Minesweeper.BLL.Logic;
using Minesweeper.BLL.Logic.Minesweeper.BLL.Logic;
using Minesweeper.BLL.Services.Interface;
using Minesweeper.DAL.Entity;
using Minesweeper.DAL.UnitOfWork.Interfaces;
using System.Collections.Concurrent;

namespace Minesweeper.BLL.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;

        
        private static readonly ConcurrentDictionary<Guid, Game> _activeGames = new();

        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<FieldDto> CreateGameAsync(int width, int height, int mines, string playerName)
        {
            var game = new Game(width, height, mines);
            _activeGames[game.Id] = game;

            return Task.FromResult(FieldDto.FromField(game.Id, game.Field));
        }

        public Task<FieldDto> OpenCellAsync(Guid gameId, int x, int y)
        {
            if (!_activeGames.TryGetValue(gameId, out var game))
                throw new Exception("Game not found");

            game.OpenCell(x, y);
            return Task.FromResult(FieldDto.FromField(gameId, game.Field));
        }

        public Task<FieldDto> ToggleFlagAsync(Guid gameId, int x, int y)
        {
            if (!_activeGames.TryGetValue(gameId, out var game))
                throw new Exception("Game not found");

            game.ToggleFlag(x, y);
            return Task.FromResult(FieldDto.FromField(gameId, game.Field));
        }

        public Task<FieldDto> GetGameFieldAsync(Guid gameId)
        {
            if (!_activeGames.TryGetValue(gameId, out var game))
                throw new Exception("Game not found");

            return Task.FromResult(FieldDto.FromField(gameId, game.Field));
        }

        public async Task SaveResultAsync(Guid gameId, string playerName, TimeSpan timeTaken, bool isWin)
        {
            if (!_activeGames.TryRemove(gameId, out _))
                throw new Exception("Game not found or already saved");

            var result = new GameResult
            {
                PlayerName = playerName,
                TimeTaken = timeTaken,
                IsWin = isWin,
                DatePlayed = DateTime.UtcNow
            };

            await _unitOfWork.GameResults.AddAsync(result);
            await _unitOfWork.SaveChangesAsync();
        }






    }

}
