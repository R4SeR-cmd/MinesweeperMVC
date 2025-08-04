using Minesweeper.DAL.Entity;

namespace Minesweeper.DAL.Repositories.Interfaces
{
    public interface IGameResultRepository
    {
        Task AddAsync(GameResult result);
        Task<List<GameResult>> GetTopResultsAsync(int count);
    }

}
