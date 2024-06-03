using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class CashTransactionRepository : ICashTransactionRepository
    {
        private readonly MyDbContext _dbContext;

        public CashTransactionRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CashTransaction> AddAsync(CashTransaction entity)
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
                var result = _dbContext.CashTransactions.FirstOrDefault(a => a.TransactionId == id);
                if (result != null)
                {
                    _dbContext.CashTransactions.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CashTransaction>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.CashTransactions.Where(x => x.TransactionId == id).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("CashTransactions not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CashTransaction> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.CashTransactions.FirstOrDefaultAsync(c => c.TransactionId == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("CashTransaction not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CashTransaction> UpdateAsync(CashTransaction entity)
        {
            try
            {
                var query = FindByIdAsync(entity.TransactionId);
                if (query != null)
                {
                    _dbContext.CashTransactions.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(entity);
                }
                else
                {
                    throw new Exception("CashTransaction not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

