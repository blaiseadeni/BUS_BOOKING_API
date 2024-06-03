using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class Stopover
    {
        [Key]
        public int StopoverId { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public string Location { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
    }

}
