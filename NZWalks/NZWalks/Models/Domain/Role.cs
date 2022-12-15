namespace NZWalks.Models.Domain
{
    public class Role
    {
        public int RoleId { get; set; }

        public string Name { get; set; }

        public List<UserRole_Model> UserRole { get; set; }
    }
}
