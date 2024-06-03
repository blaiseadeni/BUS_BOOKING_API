
using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class StopoverRepository : IStopoverRepository
    {
        private readonly MyDbContext _dbContext;

        public StopoverRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Stopover> AddAsync(Stopover entity)
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
                var result = _dbContext.Stopovers.FirstOrDefault(a => a.StopoverId == id);
                if (result != null)
                {
                    _dbContext.Stopovers.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Stopover>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.Stopovers.Where(x => x.StopoverId == id).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Stopovers not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Stopover> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Stopovers.FirstOrDefaultAsync(c => c.StopoverId == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Stopover not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Stopover> UpdateAsync(Stopover entity)
        {
            try
            {
                var query = FindByIdAsync(entity.StopoverId);
                if (query != null)
                {
                    _dbContext.Stopovers.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(entity);
                }
                else
                {
                    throw new Exception("Stopover not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}