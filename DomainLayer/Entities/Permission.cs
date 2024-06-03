using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class Permission
    {
        [Key]
        public int PermissionID { get; set; }
        public string PermissionName { get; set; }
    }
}
