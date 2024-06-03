namespace DomainLayer.Models
{
    public class ExpenseModel
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public int? BusId { get; set; }
        public int? StaffId { get; set; }
    }
}
