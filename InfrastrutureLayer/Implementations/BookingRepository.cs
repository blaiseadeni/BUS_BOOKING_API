using ApplicationLayer.Contacts;
using DomainLayer.Entities;
using InfrastrutureLayer.Data;
using InfrastrutureLayer.Services;
using Microsoft.EntityFrameworkCore;


namespace InfrastrutureLayer.Implementations
{
    public class BookingRepository : IBookingRepository
    {
        private readonly MyDbContext _dbContext;

        public BookingRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Booking> AddAsync(Booking entity)
        {
            try
            {
                var transactionService = new TransactionService();
                var result = _dbContext.Add(entity);
                var route = await _dbContext.Schedules.Include(x => x.Route).Where(x => x.Route != null && x.ScheduleId == entity.ScheduleId).FirstOrDefaultAsync();
                if (route != null) transactionService.RecordTicketSale(route.Route.Amount);
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
                var result = _dbContext.Bookings.FirstOrDefault(a => a.BookingId == id);
                if (result != null)
                {
                    _dbContext.Bookings.Remove(result);
                    return await _dbContext.SaveChangesAsync() > -1;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<IEnumerable<Booking>> FindAllAsync(int id)
        {
            try
            {
                var result = await _dbContext.Bookings.Where(x => x.BookingId == id).ToListAsync();

                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Bookings not found");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Booking> FindByIdAsync(int id)
        {
            try
            {
                var result = await _dbContext.Bookings.FirstOrDefaultAsync(c => c.BookingId == id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Booking not found");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<Booking> UpdateAsync(Booking entity)
        {
            try
            {
                var query = FindByIdAsync(entity.BookingId);
                if (query != null)
                {
                    _dbContext.Bookings.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(entity);
                }
                else
                {
                    throw new Exception("Booking not found");
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
