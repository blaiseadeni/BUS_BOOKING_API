using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }//(ex : entretien des bus, salaires).
        public int? BusId { get; set; }
        public Bus Bus { get; set; }
        public int? StaffId { get; set; }
        public Staff Staff { get; set; }
    }
}
