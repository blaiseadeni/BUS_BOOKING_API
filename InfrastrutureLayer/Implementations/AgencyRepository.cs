using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly MyDbContext _dbContext;

        public AgencyRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Agency> AddAsync(Agency entity)
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
                var result = _dbContext.Agencies.FirstOrDefault(a => a.AgencyId == id);
                if (result != null)
                {
                    _dbContext.Agencies.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Agency>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.Agencies.Where(x => x.AgencyId == id).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Agencies not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Agency> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Agencies.FirstOrDefaultAsync(c => c.AgencyId == id);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Agency not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Agency> UpdateAsync(Agency entity)
        {
            try
            {
                var query = FindByIdAsync(entity.AgencyId);
                if (query != null)
                {
                    _dbContext.Agencies.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(entity);
                }
                else
                {
                    throw new Exception("Agency not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
