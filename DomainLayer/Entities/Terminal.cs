using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class Terminal
    {
        [Key]
        public int TerminalId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<Route> OriginRoutes { get; set; }
        public ICollection<Route> DestinationRoutes { get; set; }
    }
}
