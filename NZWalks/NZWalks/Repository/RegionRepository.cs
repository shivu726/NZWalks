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

        public async Task<Region> AddRegionAsync(Region region)
        {
            //region.RegID = Guid.NewGuid();
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteRegionAsync(int Id)
        {
            var region = await _dbContext.Regions.FindAsync(Id);

            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();
            return region;

        }

        public async Task<IEnumerable<Region>> GetALlRegionsAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetRegionAsync(int Id)
        {
            return await _dbContext.Regions.FirstOrDefaultAsync(x => x.RegID == Id);
        }

        public async Task<Region> UpdateRegionAsync(int Id, Region region)
        {
            var updateRegion = await _dbContext.Regions.FindAsync(Id);

            if (updateRegion == null)
            {
                return null;
            }

            updateRegion.Code = region.Code;
            updateRegion.Area = region.Area;
            updateRegion.Name = region.Name;
            updateRegion.Lat = region.Lat;
            updateRegion.Long = region.Long;
            updateRegion.Population = region.Population;

            _dbContext.Regions.Update(updateRegion);
            await _dbContext.SaveChangesAsync();
            return updateRegion;

        }
    }
}
