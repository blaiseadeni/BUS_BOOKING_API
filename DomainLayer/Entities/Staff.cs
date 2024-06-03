using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int AgencyId { get; set; }
        public Agency Agency { get; set; }
        public byte[] Photo { get; set; } // Stockage de l'image en tant que tableau d'octets
        public ICollection<User> Users { get; set; }
    }
}
