using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;

namespace NZWalks.Repository
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly WalkDbContext _dbContext;

        public WalkDifficultyRepository(WalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<WalkDifficulty> AddWalkDifficultyAsync(WalkDifficulty walkDifficulty)
        {
            await _dbContext.WalkDifficulties.AddAsync(walkDifficulty);
            await _dbContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteWalkDifficulty(int Id)
        {
            var deleteWalkDiffi = await _dbContext.WalkDifficulties.FindAsync(Id);

            _dbContext.WalkDifficulties.Remove(deleteWalkDiffi);
            await _dbContext.SaveChangesAsync();
            return deleteWalkDiffi;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllWalkDifficultyAsync()
        {
            return await _dbContext.WalkDifficulties.ToListAsync();
        }

        public async Task<WalkDifficulty> GetWalkDifficultyByIdAsync(int Id)
        {
            return await _dbContext.WalkDifficulties.FindAsync(Id);
        }

        public async Task<WalkDifficulty> UpdateWalkDiffcultyAsync(int Id, WalkDifficulty walkDifficulty)
        {
            var updateWalkDiffi = await _dbContext.WalkDifficulties.FindAsync(Id);

            if (updateWalkDiffi == null)
            {
                return null;
            }

            updateWalkDiffi.Code = walkDifficulty.Code;

            _dbContext.WalkDifficulties.Update(updateWalkDiffi);
            await _dbContext.SaveChangesAsync();
            return updateWalkDiffi;
        }
    }
}
