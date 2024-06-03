using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class Agency
    {
        [Key]
        public int AgencyId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string? City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public ICollection<Staff> Staffs { get; set; }
        public ICollection<Route> Routes { get; set; }
        public ICollection<Bus> Buses { get; set; }
    }

}
