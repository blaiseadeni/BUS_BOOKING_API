using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class Bus
    {
        [Key]
        public int BusId { get; set; }
        public int AgencyId { get; set; }
        public Agency Agency { get; set; }
        public string BusNumber { get; set; }
        public int Capacity { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
