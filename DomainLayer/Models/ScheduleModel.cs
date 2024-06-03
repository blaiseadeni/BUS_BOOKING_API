namespace DomainLayer.Models
{
    public class ScheduleModel
    {
        public int BusId { get; set; }
        public int RouteId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int? DriverId { get; set; }
        public int? ConductorId { get; set; }
    }
}
