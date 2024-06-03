using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class CashTransaction
    {
        [Key]
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public bool IsIncome { get; set; } // true pour encaissement, false pour décaissement
    }
}
