namespace DomainLayer.Models
{
    public class StopoverModel
    {
        public int RouteId { get; set; }
        public string Location { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
    }

}
