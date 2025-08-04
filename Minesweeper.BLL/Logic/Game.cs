namespace Minesweeper.BLL.Logic
{
    namespace Minesweeper.BLL.Logic
    {
        public class Game
        {
            public Guid Id { get; private set; }
            public Field Field { get; private set; }

            public Game(int width, int height, int mineCount)
            {
                Id = Guid.NewGuid();
                Field = new Field(width, height, mineCount);
            }

            public void OpenCell(int x, int y) => Field.OpenCell(x, y);
            public void ToggleFlag(int x, int y) => Field.ToggleFlag(x, y);
        }
    }

}
