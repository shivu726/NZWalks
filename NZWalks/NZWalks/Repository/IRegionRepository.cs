using NZWalks.Models.Domain;

namespace NZWalks.Repository
{
    public interface IRegionRepository
    {
       Task<IEnumerable<Region>> GetALlRegionsAsync();

        Task<Region> GetRegionAsync(int Id);

        Task<Region> AddRegionAsync(Region region);

        Task<Region> DeleteRegionAsync(int Id);

        Task<Region> UpdateRegionAsync(int Id, Region region);
    }
}
