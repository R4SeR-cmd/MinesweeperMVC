namespace Minesweeper.BLL.DTO_s
{
    public class GameResultDto
    {
        public string PlayerName { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public bool IsWin { get; set; }
    }

}
