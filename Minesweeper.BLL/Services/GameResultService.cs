using Minesweeper.BLL.Services.Interface;
using Minesweeper.DAL.Entity;
using Minesweeper.DAL.UnitOfWork.Interfaces;

namespace Minesweeper.BLL.Services
{
    public class GameResultService : IGameResultService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameResultService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GameResult>> GetTopResultsAsync(int count)
        {
            return await _unitOfWork.GameResults.GetTopResultsAsync(count);
        }

        public async Task AddGameResultAsync(GameResult result)
        {
            await _unitOfWork.GameResults.AddAsync(result);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
