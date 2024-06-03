
using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class CashRegisterRepository : ICashRegisterRepository
    {
        private readonly MyDbContext _dbContext;

        public CashRegisterRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CashRegister> AddAsync(CashRegister entity)
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
                var result = _dbContext.CashRegisters.FirstOrDefault(a => a.RegisterId == id);
                if (result != null)
                {
                    _dbContext.CashRegisters.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CashRegister>> FindAllAsync(int id)
        {
            var result = await _dbContext.CashRegisters.Where(x => x.RegisterId == id).ToListAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Cashs not found");
            }
        }

        public async Task<CashRegister> FindByIdAsync(int id)
        {
            var result = await _dbContext.CashRegisters.FirstOrDefaultAsync(c => c.RegisterId == id);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Cash not found");
            }
        }

        public async Task<CashRegister> UpdateAsync(CashRegister entity)
        {
            var query = FindByIdAsync(entity.RegisterId);
            if (query != null)
            {
                _dbContext.CashRegisters.Update(entity);
                await _dbContext.SaveChangesAsync();
                return await Task.FromResult(entity);
            }
            else
            {
                throw new Exception("Cash not found");
            }
        }
    }
}

