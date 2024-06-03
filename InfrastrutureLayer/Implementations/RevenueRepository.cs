
using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class RevenueRepository : IRevenueRepository
    {
        private readonly MyDbContext _dbContext;

        public RevenueRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Revenue> AddAsync(Revenue entity)
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
                var result = _dbContext.Revenues.FirstOrDefault(a => a.RevenueId == id);
                if (result != null)
                {
                    _dbContext.Revenues.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Revenue>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.Revenues.Where(x => x.RevenueId == id).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Revenues not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Revenue> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Revenues.FirstOrDefaultAsync(c => c.RevenueId == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Revenue not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Revenue> UpdateAsync(Revenue entity)
        {
            try
            {
                var query = FindByIdAsync(entity.RevenueId);
                if (query != null)
                {
                    _dbContext.Revenues.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(entity);
                }
                else
                {
                    throw new Exception("Revenue not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

