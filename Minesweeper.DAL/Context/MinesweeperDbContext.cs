using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Minesweeper.DAL.Entity;

namespace Minesweeper.DAL.Context
{
    public class MinesweeperDbContext : DbContext
    {
        public DbSet<GameResult> GameResults { get; set; }
        public MinesweeperDbContext(DbContextOptions<MinesweeperDbContext> options) : base(options)
        {

        }

       
    }
}
