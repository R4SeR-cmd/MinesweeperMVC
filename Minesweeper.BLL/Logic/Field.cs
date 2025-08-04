using Minesweeper.DAL.Entity;

namespace Minesweeper.BLL.Logic
{
    public class Field
    {
        public int Width { get; }
        public int Height { get; }
        public Cell[,] Cells { get; }

        private bool _minesGenerated = false;
        private int _mineCount;

        public Field(int width, int height, int mineCount)
        {
            Width = width;
            Height = height;
            _mineCount = mineCount;
            Cells = new Cell[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    Cells[x, y] = new Cell();
        }

        public void OpenCell(int x, int y)
        {
            if (!_minesGenerated)
            {
                GenerateMines(x, y);
                _minesGenerated = true;
            }

            if (IsOutOfBounds(x, y) || Cells[x, y].IsOpened || Cells[x, y].IsFlagged)
                return;

            Cells[x, y].IsOpened = true;

            if (Cells[x, y].AdjacentMines == 0 && !Cells[x, y].IsMine)
            {
                // Рекурсивне відкриття сусідів
                foreach (var (nx, ny) in GetNeighbors(x, y))
                    OpenCell(nx, ny);
            }
        }

        public void ToggleFlag(int x, int y)
        {
            if (IsOutOfBounds(x, y) || Cells[x, y].IsOpened)
                return;

            Cells[x, y].IsFlagged = !Cells[x, y].IsFlagged;
        }

        private void GenerateMines(int startX, int startY)
        {
            var rand = new Random();
            int placed = 0;

            while (placed < _mineCount)
            {
                int x = rand.Next(Width);
                int y = rand.Next(Height);

                // не ставимо міну на першу відкриту клітинку
                if ((x == startX && y == startY) || Cells[x, y].IsMine)
                    continue;

                Cells[x, y].IsMine = true;
                placed++;
            }

            CalculateAdjacency();
        }

        private void CalculateAdjacency()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (Cells[x, y].IsMine)
                    {
                        Cells[x, y].AdjacentMines = -1;
                        continue;
                    }

                    int count = 0;
                    foreach (var (nx, ny) in GetNeighbors(x, y))
                        if (Cells[nx, ny].IsMine) count++;

                    Cells[x, y].AdjacentMines = count;
                }
            }
        }

        private List<(int, int)> GetNeighbors(int x, int y)
        {
            var neighbors = new List<(int, int)>();

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0) continue;

                    int nx = x + dx;
                    int ny = y + dy;

                    if (!IsOutOfBounds(nx, ny))
                        neighbors.Add((nx, ny));
                }
            }

            return neighbors;
        }

        private bool IsOutOfBounds(int x, int y) =>
            x < 0 || y < 0 || x >= Width || y >= Height;
    }

}
