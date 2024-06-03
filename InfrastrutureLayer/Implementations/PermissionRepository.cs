
using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly MyDbContext _dbContext;

        public PermissionRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Permission> AddAsync(Permission entity)
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
                var result = _dbContext.Permissions.FirstOrDefault(a => a.PermissionID == id);
                if (result != null)
                {
                    _dbContext.Permissions.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Permission>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.Permissions.Where(x => x.PermissionID == id).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Permissions not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Permission> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Permissions.FirstOrDefaultAsync(c => c.PermissionID == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Permission not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Permission> UpdateAsync(Permission entity)
        {
            try
            {
                var query = FindByIdAsync(entity.PermissionID);
                if (query != null)
                {
                    _dbContext.Permissions.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(entity);
                }
                else
                {
                    throw new Exception("Permission not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
