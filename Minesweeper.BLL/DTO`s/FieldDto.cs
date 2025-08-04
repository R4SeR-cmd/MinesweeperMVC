namespace Minesweeper.BLL.DTO_s
{
    public class FieldDto
    {
        public Guid GameId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public CellDto[][] Cells { get; set; }

        public static FieldDto FromField(Guid gameId, Logic.Field field)
        {
            var dto = new FieldDto
            {
                GameId = gameId,
                Width = field.Width,
                Height = field.Height,
                Cells = new CellDto[field.Width][]
            };

            for (int x = 0; x < field.Width; x++)
            {
                dto.Cells[x] = new CellDto[field.Height];
                for (int y = 0; y < field.Height; y++)
                {
                    var cell = field.Cells[x, y];
                    dto.Cells[x][y] = new CellDto
                    {
                        X = cell.X,
                        Y = cell.Y,
                        IsOpened = cell.IsOpened,
                        IsFlagged = cell.IsFlagged,
                        IsMine = cell.IsOpened ? cell.IsMine : false,
                        AdjacentMines = cell.IsOpened ? cell.AdjacentMines : 0
                    };
                }
            }

            return dto;
        }
    }

  

}
