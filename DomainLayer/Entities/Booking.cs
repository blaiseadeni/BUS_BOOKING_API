using DomainLayer.Models;
using System.ComponentModel.DataAnnotations;
namespace DomainLayer.Entities
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfSeats { get; set; }
        public BookingStatus Status { get; set; }
        public Cancellation Cancellation { get; set; } // Navigation property
    }
}
