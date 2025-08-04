namespace Minesweeper.DAL.Entity
{
    public class GameResult
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public DateTime DatePlayed { get; set; }
        public bool IsWin { get; set; }
    }

}
