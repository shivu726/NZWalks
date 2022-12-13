using NZWalks.Models.Domain;

namespace NZWalks.Repository
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>> GetAllWalkDifficultyAsync();

        Task<WalkDifficulty> GetWalkDifficultyByIdAsync(int Id);

        Task<WalkDifficulty> AddWalkDifficultyAsync(WalkDifficulty walkDifficulty);

        Task<WalkDifficulty> UpdateWalkDiffcultyAsync(int Id, WalkDifficulty walkDifficulty);

        Task<WalkDifficulty> DeleteWalkDifficulty(int Id);

    }
}
