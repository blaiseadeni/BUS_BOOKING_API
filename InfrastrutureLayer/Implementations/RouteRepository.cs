
using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class RouteRepository : IRouteRepository
    {
        private readonly MyDbContext _dbContext;

        public RouteRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Route> AddAsync(Route entity)
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
                var result = _dbContext.Routes.FirstOrDefault(a => a.RouteId == id);
                if (result != null)
                {
                    _dbContext.Routes.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Route>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.Routes.Where(x => x.RouteId == id).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Routes not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Route> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Routes.FirstOrDefaultAsync(c => c.RouteId == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Route not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Route> UpdateAsync(Route entity)
        {
            try
            {
                var query = FindByIdAsync(entity.RouteId);
                if (query != null)
                {
                    _dbContext.Routes.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(entity);
                }
                else
                {
                    throw new Exception("Route not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
