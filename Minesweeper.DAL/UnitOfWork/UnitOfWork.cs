using Minesweeper.DAL.Context;
using Minesweeper.DAL.Repositories;
using Minesweeper.DAL.Repositories.Interfaces;
using Minesweeper.DAL.UnitOfWork.Interfaces;

namespace Minesweeper.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MinesweeperDbContext _context;
        public IGameResultRepository GameResults { get; }

        public UnitOfWork(MinesweeperDbContext context)
        {
            _context = context;
            GameResults = new GameResultRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
