namespace DomainLayer.Models
{
    public class BookingModel
    {
        public int CustomerId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
