using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Entities
{
    public class Route
    {
        [Key]
        public int RouteId { get; set; }
        public int AgencyId { get; set; }
        public Agency Agency { get; set; }
        public int OriginTerminalId { get; set; }
        public int DestinationTerminalId { get; set; }
        public Terminal Terminal { get; set; }
        public decimal Amount { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
