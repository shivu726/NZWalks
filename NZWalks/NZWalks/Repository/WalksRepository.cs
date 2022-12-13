using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;

namespace NZWalks.Repository
{
    public class WalksRepository : IWalksRepository
    {
        private readonly WalkDbContext _dbContext;

        public WalksRepository(WalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Walk> AddWalkAsync(Walk walk)
        {
            //walk.WalkID = Guid.NewGuid();
            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteWalkAsync(int Id)
        {
            var delWalk = await _dbContext.Walks.FindAsync(Id);

            _dbContext.Walks.Remove(delWalk);
            await _dbContext.SaveChangesAsync();
            return delWalk;
        }

        public async Task<IEnumerable<Walk>> GetAllWalksAsync()
        {
            return await _dbContext.Walks
                .Include(x => x.Regions)
                .Include(x => x.WalkDifficulties)
                .ToListAsync();
        }

        public async Task<Walk> GetWalkByIdAsync(int Id)
        {
            return await _dbContext.Walks
                .Include(x => x.Regions)
                .Include(x => x.WalkDifficulties)
                .FirstOrDefaultAsync(x => x.WalkID == Id);
        }

        public async Task<Walk> UpdateWalkAsync(int Id, Walk walk)
        {
            var getWalk = await _dbContext.Walks.FindAsync(Id);

            if (getWalk == null)
            {
                return null;
            }

            getWalk.Name = walk.Name;
            getWalk.Length = walk.Length;
            getWalk.RegionID = walk.RegionID;
            getWalk.WalkDifficultyID = walk.WalkDifficultyID;

            _dbContext.Walks.Update(getWalk);
            await _dbContext.SaveChangesAsync();

            return getWalk;
        }
    }
}
