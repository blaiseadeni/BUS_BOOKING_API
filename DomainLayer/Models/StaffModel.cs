namespace DomainLayer.Models
{
    public class StaffModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int AgencyId { get; set; }
        public byte[] ImageFile { get; set; }
    }
}
