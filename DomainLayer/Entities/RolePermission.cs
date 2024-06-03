using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class RolePermission
    {
        [Key]
        public int Id { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
        public int PermissionID { get; set; }
        public Permission Permission { get; set; }
    }
}
