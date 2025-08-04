using Microsoft.EntityFrameworkCore;
using Minesweeper.DAL.Context;
using Minesweeper.DAL.Entity;
using Minesweeper.DAL.Repositories.Interfaces;

namespace Minesweeper.DAL.Repositories
{
    public class GameResultRepository : IGameResultRepository
    {
        private readonly MinesweeperDbContext _context;

        public GameResultRepository(MinesweeperDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(GameResult result)
        {
            await _context.GameResults.AddAsync(result);
        }

        public async Task<List<GameResult>> GetTopResultsAsync(int count)
        {
            return await _context.GameResults
                .OrderBy(r => r.TimeTaken)
                .Take(count)
                .ToListAsync();
        }
    }

}
