using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyDbContext _dbContext;

        public AccountRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Account> AddAsync(Account entity)
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
                var result = _dbContext.Accounts.FirstOrDefault(a => a.AccountId == id);
                if (result != null)
                {
                    _dbContext.Accounts.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Account>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.Accounts.Where(x => x.AccountId == id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Account> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Accounts.FirstOrDefaultAsync(c => c.AccountId == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Account not found");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<Account> UpdateAsync(Account entity)
        {
            try
            {
                var query = FindByIdAsync(entity.AccountId);
                if (query != null)
                {
                    _dbContext.Accounts.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(entity);
                }
                else
                {
                    throw new Exception("Account not found");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
