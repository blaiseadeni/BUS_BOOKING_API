using DomainLayer.Entities;
using InfrastrutureLayer.Data;

namespace InfrastrutureLayer.Services
{
    public class TransactionService
    {
        public readonly MyDbContext _dbContext;

        public TransactionService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public TransactionService()
        {

        }
        public void RecordTicketSale(decimal amount)
        {

            var revenueAccount = _dbContext.Accounts.SingleOrDefault(a => a.AccountName == "Ticket Sales");
            if (revenueAccount == null)
            {
                revenueAccount = new Account
                {
                    AccountName = "Ticket Sales",
                    AccountType = "Revenue"
                };
                _dbContext.Accounts.Add(revenueAccount);
                _dbContext.SaveChanges();
            }

            var revenue = new Revenue
            {
                Amount = amount,
                RevenueDate = DateTime.Now,
                Description = revenueAccount.AccountName,
            };
            _dbContext.Revenues.Add(revenue);

            var cash = new CashTransaction
            {
                Amount = amount,
                Description = revenueAccount.AccountName,
                TransactionDate = DateTime.Now,
                IsIncome = true,
            };
            _dbContext.CashTransactions.Add(cash);


            var transaction = new Transaction
            {
                AccountId = revenueAccount.AccountId,
                Amount = amount,
                TransactionDate = DateTime.Now,
                Description = revenueAccount.AccountName
            };
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
        }


        public void RecordExpense(decimal amount, string description)
        {
            var expenseAccount = _dbContext.Accounts.SingleOrDefault(a => a.AccountName == "Operating Expenses");
            if (expenseAccount == null)
            {
                expenseAccount = new Account
                {
                    AccountName = "Operating Expenses",
                    AccountType = "Expense"
                };
                _dbContext.Accounts.Add(expenseAccount);
                _dbContext.SaveChanges();
            }

            var cash = new CashTransaction
            {
                Amount = amount,
                Description = description,
                TransactionDate = DateTime.Now,
                IsIncome = false,
            };
            _dbContext.CashTransactions.Add(cash);

            var transaction = new Transaction
            {
                AccountId = expenseAccount.AccountId,
                Amount = amount, // Negative value for expenses
                TransactionDate = DateTime.Now,
                Description = description
            };
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
        }

        public void RecordTransaction(int accountId, decimal amount, string description)
        {

            var transaction = new Transaction
            {
                AccountId = accountId,
                Amount = amount,
                TransactionDate = DateTime.Now,
                Description = description
            };
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
        }
    }
}
