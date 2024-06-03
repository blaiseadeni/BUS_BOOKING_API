
namespace DomainLayer.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; } // 'Revenue', 'Expense', 'Asset', 'Liability'
        public ICollection<Transaction> Transactions { get; set; }
    }
}
