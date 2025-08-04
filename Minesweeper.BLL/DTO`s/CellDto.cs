namespace Minesweeper.BLL.DTO_s
{
    public class CellDto
    {
        public int X { get; set; }              
        public int Y { get; set; }             
        public bool IsOpened { get; set; }     
        public bool IsFlagged { get; set; }     
        public bool IsMine { get; set; }        
        public int AdjacentMines { get; set; }  
    }

}
