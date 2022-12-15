using NZWalks.Models.Domain;

namespace NZWalks.Repository
{
    public class StaticUserRepository : IUserRepository
    {
        private List<UserInfo> users = new List<UserInfo>();
        //{
        //    new UserInfo()
        //    {
        //        FirstName = "Read Only", LastName = "User", EmailAddress = "readonly@user.com", ID = 1,
        //        Username = "readonly@user.com", Password = "admin1234", Roles = new List<string>{"reader"}
        //    },
        //    new UserInfo()
        //    {
        //        FirstName = "Read Write", LastName = "User", EmailAddress = "readwrite@user.com", ID = 2,
        //        Username = "readwrite@user.com", Password = "test1234", Roles = new List<string>{"reader", "writer"}
        //    }
        //};
        public async Task<UserInfo> UserAuthenticationAsync(string username, string password)
        {
            // InvariantCultureIgnoreCase this method removes to check upper case and lower case for username..

            var result = users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && x.Password == password);
            
            return result;
        }
    }
}
