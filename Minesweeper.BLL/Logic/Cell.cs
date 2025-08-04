namespace Minesweeper.BLL.Logic
{
    public class Cell
    {
        public int X { get; }
        public int Y { get; }

        public bool IsOpened { get; internal set; }
        public bool IsFlagged { get; internal set; }
        public bool IsMine { get; set; }
        public int AdjacentMines { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Cell()
        {
        }

        public void Open()
        {
            IsOpened = true;
        }

        public void ToggleFlag()
        {
            if (!IsOpened)
                IsFlagged = !IsFlagged;
        }
    }
}



