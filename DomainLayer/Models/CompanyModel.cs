namespace DomainLayer.Models
{
    public class CompanyModel
    {
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
        public byte[] ImageFile { get; set; }
    }
}
