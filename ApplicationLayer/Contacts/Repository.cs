using DomainLayer.Entities;

namespace ApplicationLayer.Contacts
{
    public interface IUserRepository : IGenericRepository<User> { }
    public interface ICompanyRepository : IGenericRepository<Company> { }
    public interface IRoleRepository : IGenericRepository<Role> { }
    public interface IPermissionRepository : IGenericRepository<Permission> { }
    public interface IRolePermissionRepository : IGenericRepository<RolePermission> { }
    public interface IAgencyRepository : IGenericRepository<Agency> { }
    public interface ICustomerRepository : IGenericRepository<Customer> { }
    public interface IBusRepository : IGenericRepository<Bus> { }
    public interface IRouteRepository : IGenericRepository<Route> { }
    public interface IScheduleRepository : IGenericRepository<Schedule> { }
    public interface ITerminalRepository : IGenericRepository<Terminal> { }
    public interface ICancellationRepository : IGenericRepository<Cancellation> { }
    public interface IBookingRepository : IGenericRepository<Booking> { }
    public interface IStaffRepository : IGenericRepository<Staff> { }
    public interface IStopoverRepository : IGenericRepository<Stopover> { }
    public interface IExpenseRepository : IGenericRepository<Expense> { }
    public interface IAccountRepository : IGenericRepository<Account> { }
    public interface ITransactionRepository : IGenericRepository<Transaction> { }
    public interface IRevenueRepository : IGenericRepository<Revenue> { }
    public interface ICashTransactionRepository : IGenericRepository<CashTransaction> { }
    public interface ICashRegisterRepository : IGenericRepository<CashRegister> { }

}
