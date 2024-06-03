
using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class TerminalRepository : ITerminalRepository
    {
        private readonly MyDbContext _dbContext;

        public TerminalRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Terminal> AddAsync(Terminal entity)
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
                var result = _dbContext.Terminals.FirstOrDefault(a => a.TerminalId == id);
                if (result != null)
                {
                    _dbContext.Terminals.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Terminal>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.Terminals.Where(x => x.TerminalId == id).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Terminals not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Terminal> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Terminals.FirstOrDefaultAsync(c => c.TerminalId == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Terminal not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Terminal> UpdateAsync(Terminal entity)
        {
            try
            {
                var query = FindByIdAsync(entity.TerminalId);
                if (query != null)
                {
                    _dbContext.Terminals.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(entity);
                }
                else
                {
                    throw new Exception("Terminal not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
