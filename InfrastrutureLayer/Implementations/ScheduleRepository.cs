
using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly MyDbContext _dbContext;

        public ScheduleRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Schedule> AddAsync(Schedule entity)
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
                var result = _dbContext.Schedules.FirstOrDefault(a => a.ScheduleId == id);
                if (result != null)
                {
                    _dbContext.Schedules.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Schedule>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.Schedules.Where(x => x.ScheduleId == id).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Schedules not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Schedule> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Schedules.FirstOrDefaultAsync(c => c.ScheduleId == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Schedule not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Schedule> UpdateAsync(Schedule entity)
        {
            try
            {
                var query = FindByIdAsync(entity.ScheduleId);
                if (query != null)
                {
                    _dbContext.Schedules.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(entity);
                }
                else
                {
                    throw new Exception("Schedule not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
