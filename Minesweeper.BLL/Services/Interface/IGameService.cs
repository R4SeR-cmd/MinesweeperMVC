using Minesweeper.BLL.DTO_s;

namespace Minesweeper.BLL.Services.Interface
{
    public interface IGameService
    {
        Task<FieldDto> OpenCellAsync(Guid gameId, int x, int y);
        Task<FieldDto> ToggleFlagAsync(Guid gameId, int x, int y);
        Task<FieldDto> GetGameFieldAsync(Guid gameId);
        Task<FieldDto> CreateGameAsync(int width, int height, int mineCount, string playerName);
    }
}
