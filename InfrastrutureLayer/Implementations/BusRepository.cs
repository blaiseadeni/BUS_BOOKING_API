using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class BusRepository : IBusRepository
    {
        private readonly MyDbContext _dbContext;

        public BusRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Bus> AddAsync(Bus entity)
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
                var result = _dbContext.Buses.FirstOrDefault(a => a.BusId == id);
                if (result != null)
                {
                    _dbContext.Buses.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Bus>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.Buses.Where(x => x.BusId == id).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Buses not found");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Bus> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Buses.FirstOrDefaultAsync(c => c.BusId == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Bus not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Bus> UpdateAsync(Bus entity)
        {
            try
            {
                var query = FindByIdAsync(entity.BusId);
                if (query != null)
                {
                    _dbContext.Buses.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(entity);
                }
                else
                {
                    throw new Exception("Bus not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
