using Minesweeper.DAL.Repositories.Interfaces;

namespace Minesweeper.DAL.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGameResultRepository GameResults { get; }
        Task<int> SaveChangesAsync();
    }

}
