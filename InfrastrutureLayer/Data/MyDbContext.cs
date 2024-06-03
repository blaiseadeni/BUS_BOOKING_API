using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfrastrutureLayer.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Cancellation> Cancellations { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Stopover> Stopovers { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<CashTransaction> CashTransactions { get; set; }
        public DbSet<CashRegister> CashRegisters { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}