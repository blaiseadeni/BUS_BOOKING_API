namespace DomainLayer.Models
{
    public class CashTransactionModel
    {
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public bool IsIncome { get; set; } // true pour encaissement, false pour décaissement
    }
}
