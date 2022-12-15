using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;

namespace NZWalks.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly WalkDbContext dbContext;

        public UserRepository(WalkDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserInfo> UserAuthenticationAsync(string username, string password)
        {
                // compare username and password
            var user = dbContext.Users.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == password);

            if (user == null)
            {
                return null;
            }

                // retrieve user here...
            var userRoles = await dbContext.UserRoles.Where(x => x.UserId == user.ID).ToListAsync();

            if (userRoles.Any())
            {
                user.Roles = new List<string>();
                foreach(var userRole in userRoles)
                {
                    // retrieve user roles here...
                    var role = await dbContext.Roles.FirstOrDefaultAsync(x => x.RoleId == userRole.Role_Id);
                    if (role != null)
                    {
                        user.Roles.Add(role.Name);
                    }
                }
            }

            user.Password = null;       // make password null to not float throughout the application...
            return user;
        }
    }
}
