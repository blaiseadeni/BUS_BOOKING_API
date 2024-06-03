using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly MyDbContext _dbContext;

        public RoleRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Role> AddAsync(Role entity)
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
                var result = _dbContext.Roles.FirstOrDefault(a => a.RoleId == id);
                if (result != null)
                {
                    _dbContext.Roles.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Role>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.Roles.Where(x => x.RoleId == id).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Roles not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Role> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Roles.FirstOrDefaultAsync(c => c.RoleId == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Role not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Role> UpdateAsync(Role entity)
        {
            try
            {
                var query = FindByIdAsync(entity.RoleId);
                if (query != null)
                {
                    _dbContext.Roles.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(entity);
                }
                else
                {
                    throw new Exception("Role not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
