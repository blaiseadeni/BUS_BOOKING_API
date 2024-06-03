using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class CashRegister
    {
        [Key]
        public int RegisterId { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
