using NZWalks.Models.Domain;

namespace NZWalks.Repository
{
    public interface IWalksRepository
    {
        Task<IEnumerable<Walk>> GetAllWalksAsync();

        Task<Walk> GetWalkByIdAsync(int Id);

        Task<Walk> AddWalkAsync(Walk walk);

        Task<Walk> DeleteWalkAsync(int Id);

        Task<Walk> UpdateWalkAsync(int Id, Walk walk);
    }
}
