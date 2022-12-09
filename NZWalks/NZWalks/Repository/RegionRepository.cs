using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;

namespace NZWalks.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly WalkDbContext _dbContext;

        public RegionRepository(WalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Region>> GetALlRegionsAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }
    }
}
