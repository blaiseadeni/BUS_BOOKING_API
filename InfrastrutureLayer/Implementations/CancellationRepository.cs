
using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class CancellationRepository : ICancellationRepository
    {
        private readonly MyDbContext _dbContext;

        public CancellationRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cancellation> AddAsync(Cancellation entity)
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
                var result = _dbContext.Cancellations.FirstOrDefault(a => a.CancellationId == id);
                if (result != null)
                {
                    _dbContext.Cancellations.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Cancellation>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.Cancellations.Where(x => x.CancellationId == id).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Cancellations not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cancellation> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Cancellations.FirstOrDefaultAsync(c => c.CancellationId == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Cancellation not found");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Cancellation> UpdateAsync(Cancellation entity)
        {
            try
            {
                var query = FindByIdAsync(entity.CancellationId);
                if (query != null)
                {
                    _dbContext.Cancellations.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(entity);
                }
                else
                {
                    throw new Exception("Cancellation not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
