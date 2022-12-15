namespace NZWalks.Models.Domain
{
    public class UserRole_Model
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public UserInfo Users { get; set; }

        public int Role_Id { get; set; }

        public Role Roles { get; set; }
    }
}
