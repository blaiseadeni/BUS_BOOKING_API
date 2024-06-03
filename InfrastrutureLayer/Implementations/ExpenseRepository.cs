
using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using InfrastrutureLayer.Services;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly MyDbContext _dbContext;

        public ExpenseRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Expense> AddAsync(Expense entity)
        {
            try
            {
                var result = _dbContext.Add(entity);
                var transactionService = new TransactionService();
                transactionService.RecordExpense(entity.Amount,entity.Description);
                await _dbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = _dbContext.Expenses.FirstOrDefault(a => a.ExpenseId == id);
                if (result != null)
                {
                    _dbContext.Expenses.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Expense>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.Expenses.Where(x => x.ExpenseId == id).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Expenses not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Expense> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Expenses.FirstOrDefaultAsync(c => c.ExpenseId == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Expense not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Expense> UpdateAsync(Expense entity)
        {
            try
            {
                var query = FindByIdAsync(entity.ExpenseId);
                if (query != null)
                {
                    _dbContext.Expenses.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(entity);
                }
                else
                {
                    throw new Exception("Expense not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
