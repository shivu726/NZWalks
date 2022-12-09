using NZWalks.Models.Domain;

namespace NZWalks.Repository
{
    public interface IRegionRepository
    {
       Task<IEnumerable<Region>> GetALlRegionsAsync();
    }
}
