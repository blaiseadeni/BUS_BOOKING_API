using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}
