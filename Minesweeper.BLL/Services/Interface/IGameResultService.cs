using Minesweeper.DAL.Entity;

namespace Minesweeper.BLL.Services.Interface
{
    public interface IGameResultService
    {
        Task<List<GameResult>> GetTopResultsAsync(int count);
        Task AddGameResultAsync(GameResult result);
    }
    
}
