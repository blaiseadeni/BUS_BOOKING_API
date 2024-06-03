
using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly MyDbContext _dbContext;

        public CompanyRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Company> AddAsync(Company entity)
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

                // Créer l'objet Company
                var company = new Company
                {
                    Name = entity.Name,
                    CreationDate = entity.CreationDate,
                    RegistrationNumber = entity.RegistrationNumber,
                    NationalId = entity.NationalId,
                    Phone = entity.Phone,
                    Email = entity.Email,
                    City = entity.City,
                    Address = entity.Address,
                    SocialSecurityNumber = entity.SocialSecurityNumber,
                    PensionFundNumber = entity.PensionFundNumber,
                    TaxNumber = entity.TaxNumber,
                    Image = imageData // Enregistrer l'image en tant que tableau d'octets
                };

                // Ajouter et sauvegarder dans la base de données
                var result = _dbContext.Add(company);
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
                var result = _dbContext.Companies.FirstOrDefault(a => a.CompanyId == id);
                if (result != null)
                {
                    _dbContext.Companies.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Company>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.Companies.Where(x => x.CompanyId == id).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Companies not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Company> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Company not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Company> UpdateAsync(Company entity)
        {
            try
            {
                var query = FindByIdAsync(entity.CompanyId);
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
                    query.Name = entity.Name,
                    query.CreationDate = entity.CreationDate,
                    query.RegistrationNumber = entity.RegistrationNumber,
                    query.NationalId = entity.NationalId,
                    query.Phone = entity.Phone,
                    query.Email = entity.Email,
                    query.City = entity.City,
                    query.Address = entity.Address,
                    query.SocialSecurityNumber = entity.SocialSecurityNumber,
                    query.PensionFundNumber = entity.PensionFundNumber,
                    query.TaxNumber = entity.TaxNumber,
                    query.Image = imageData // Enregistrer l'image en tant que tableau d'octets

                    _dbContext.Companies.Update(query);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(query);
                }
                else
                {
                    throw new Exception("Company not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
