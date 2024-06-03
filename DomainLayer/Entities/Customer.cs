using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }

}
