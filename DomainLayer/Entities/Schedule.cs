using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{

    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int? DriverId { get; set; }
        public Staff Driver { get; set; }
        public int? ConductorId { get; set; }
        public Staff Conductor { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }

}
