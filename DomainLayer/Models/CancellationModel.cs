namespace DomainLayer.Models
{
    public class CancellationModel
    {
        public int BookingId { get; set; }
        public DateTime CancellationDate { get; set; }
        public string Reason { get; set; }
    }
}
