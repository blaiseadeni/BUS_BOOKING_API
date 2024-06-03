using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private readonly MyDbContext _dbContext;

        public RolePermissionRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RolePermission> AddAsync(RolePermission entity)
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
                var result = _dbContext.RolePermissions.FirstOrDefault(a => a.PermissionID == id);
                if (result != null)
                {
                    _dbContext.RolePermissions.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<RolePermission>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.RolePermissions.Where(x => x.PermissionID == id).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("RolePermissions not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RolePermission> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.RolePermissions.FirstOrDefaultAsync(c => c.PermissionID == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("RolePermission not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RolePermission> UpdateAsync(RolePermission entity)
        {
            try
            {
                var query = FindByIdAsync(entity.PermissionID);
                if (query != null)
                {
                    _dbContext.RolePermissions.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(entity);
                }
                else
                {
                    throw new Exception("RolePermission not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
