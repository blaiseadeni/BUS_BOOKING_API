
using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class StaffRepository : IStaffRepository
    {
        private readonly MyDbContext _dbContext;

        public StaffRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Staff> AddAsync(Staff entity)
        {
            try
            {
                byte[] imageData = null;
                if (entity.ImageFile != null && entity.ImageFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await entity.ImageFile.CopyToAsync(memoryStream);
                        imageData = memoryStream.ToArray();
                    }
                }
                // Créer l'objet Staff
                var staff = new Staff
                {
                    Position = entity.Position,
                    LastName = entity.LastName,
                    FirstName = entity.FirstName,
                    AgencyId = entity.AgencyId,
                    Photo = imageData // Enregistrer l'image en tant que tableau d'octets
                };
                var result = _dbContext.Add(staff);
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
                var result = _dbContext.Staffs.FirstOrDefault(a => a.StaffId == id);
                if (result != null)
                {
                    _dbContext.Staffs.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Staff>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.Staffs.Where(x => x.StaffId == id).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Staffs not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Staff> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Staffs.FirstOrDefaultAsync(c => c.StaffId == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Staff not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Staff> UpdateAsync(Staff entity)
        {
            try
            {
                var query = FindByIdAsync(entity.StaffId);
                if (query != null)
                {
                    byte[] imageData = null;
                    if (entity.ImageFile != null && entity.ImageFile.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await entity.ImageFile.CopyToAsync(memoryStream);
                            imageData = memoryStream.ToArray();
                        }
                    }

                    query.Position = entity.Position,
                    query.LastName = entity.LastName,
                    query.FirstName = entity.FirstName,
                    query.AgencyId = entity.AgencyId,
                    query.Photo = imageData // Enregistrer l'image en tant que tableau d'octets

                    _dbContext.Staffs.Update(query);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(query);
                }
                else
                {
                    throw new Exception("Staff not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
