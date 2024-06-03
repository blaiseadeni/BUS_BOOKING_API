
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class Cancellation
    {
        [Key]
        public int CancellationId { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public DateTime CancellationDate { get; set; }
        public string Reason { get; set; }
    }
}
