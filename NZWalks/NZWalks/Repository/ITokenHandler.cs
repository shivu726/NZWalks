using NZWalks.Models.Domain;

namespace NZWalks.Repository
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(UserInfo userInfo);
    }
}
