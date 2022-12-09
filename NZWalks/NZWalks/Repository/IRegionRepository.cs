using NZWalks.Models.Domain;

namespace NZWalks.Repository
{
    public interface IRegionRepository
    {
       Task<IEnumerable<Region>> GetALlRegionsAsync();

        Task<Region> GetRegionAsync(Guid Id);

        Task<Region> AddRegionAsync(Region region);

        Task<Region> DeleteRegionAsync(Guid Id);

        Task<Region> UpdateRegionAsync(Guid Id, Region region);
    }
}
