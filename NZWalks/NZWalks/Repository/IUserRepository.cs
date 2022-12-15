using NZWalks.Models.Domain;

namespace NZWalks.Repository
{
    public interface IUserRepository
    {
        Task<UserInfo> UserAuthenticationAsync(string username, string password);
    }
}
