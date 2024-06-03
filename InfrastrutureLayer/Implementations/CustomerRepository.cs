using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MyDbContext _dbContext;

        public CustomerRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> AddAsync(Customer entity)
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
                var result = _dbContext.Customers.FirstOrDefault(a => a.CustomerId == id);
                if (result != null)
                {
                    _dbContext.Customers.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Customer>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.Customers.Where(x => x.CustomerId == id).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Customers not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Customer> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Customer not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Customer> UpdateAsync(Customer entity)
        {
            try
            {
                var query = FindByIdAsync(entity.CustomerId);
                if (query != null)
                {
                    _dbContext.Customers.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(entity);
                }
                else
                {
                    throw new Exception("Customer not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
