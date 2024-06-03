
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class Revenue
    {
        [Key]
        public int RevenueId { get; set; }
        public decimal Amount { get; set; }
        public DateTime RevenueDate { get; set; }
        public string Description { get; set; }
    }
}
