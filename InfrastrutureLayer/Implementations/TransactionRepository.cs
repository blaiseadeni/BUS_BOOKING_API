
using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MyDbContext _dbContext;

        public TransactionRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Transaction> AddAsync(Transaction entity)
        {
            try
            {
                var result = _dbContext.Add(entity);
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
                var result = _dbContext.Transactions.FirstOrDefault(a => a.TransactionId == id);
                if (result != null)
                {
                    _dbContext.Transactions.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Transaction>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.Transactions.Where(x => x.TransactionId == id).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Transactions not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Transaction> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Transactions.FirstOrDefaultAsync(c => c.TransactionId == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Transaction not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Transaction> UpdateAsync(Transaction entity)
        {
            try
            {
                var query = FindByIdAsync(entity.TransactionId);
                if (query != null)
                {
                    _dbContext.Transactions.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(entity);
                }
                else
                {
                    throw new Exception("Transaction not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

