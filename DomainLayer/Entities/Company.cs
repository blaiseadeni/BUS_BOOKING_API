
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? NationalId { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public int SocialSecurityNumber { get; set; }
        public int PensionFundNumber { get; set; }
        public int TaxNumber { get; set; }
        public byte[] Image { get; set; } // Stockage de l'image en tant que tableau d'octets
    }
}
