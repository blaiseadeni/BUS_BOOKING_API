namespace DomainLayer.Models
{

    public class RouteModel
    {
        public int AgencyId { get; set; }
        public int OriginTerminalId { get; set; }
        public int DestinationTerminalId { get; set; }
        public decimal Amount { get; set; }
    }
}
