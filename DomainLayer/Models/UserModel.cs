namespace DomainLayer.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public int StaffId { get; set; }
        public int RoleID { get; set; }
    }
}
