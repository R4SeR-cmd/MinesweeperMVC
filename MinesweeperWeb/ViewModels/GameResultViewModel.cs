namespace MinesweeperWeb.ViewModels
{
    public class GameResultViewModel
    {
        public string PlayerName { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public bool IsWin { get; set; }
        public DateTime DatePlayed { get; set; }
    }
}
