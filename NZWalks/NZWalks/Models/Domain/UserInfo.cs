using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.Models.Domain
{
    public class UserInfo
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]     // this property is not added to the database so we are not mapping this with table
        public List<string> Roles { get; set; }

        public List<UserRole_Model>  UserRole { get; set; }
    }
}
