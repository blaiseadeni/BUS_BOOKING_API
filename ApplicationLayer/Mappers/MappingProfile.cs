using AutoMapper;
using DomainLayer.Entities;
using DomainLayer.Models;

namespace ApplicationLayer.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();

            CreateMap<Company, CompanyModel>();
            CreateMap<CompanyModel, Company>();

            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerModel, Customer>();

            CreateMap<Role, RoleModel>();
            CreateMap<RoleModel, Role>();

            CreateMap<Permission, PermissionModel>();
            CreateMap<PermissionModel, Permission>();

            CreateMap<RolePermission, RolePermissionModel>();
            CreateMap<RolePermissionModel, RolePermission>();

            CreateMap<Agency, AgencyModel>();
            CreateMap<AgencyModel, Agency>();

            CreateMap<User, CustomerModel>();
            CreateMap<CustomerModel, User>();

            CreateMap<Bus, BusModel>();
            CreateMap<BusModel, Bus>();

            CreateMap<Route, RouteModel>();
            CreateMap<RouteModel, Route>();

            CreateMap<Schedule, ScheduleModel>();
            CreateMap<ScheduleModel, Schedule>();

            CreateMap<Terminal, TerminalModel>();
            CreateMap<TerminalModel, Terminal>();

            CreateMap<Cancellation, CancellationModel>();
            CreateMap<CancellationModel, Cancellation>();

            CreateMap<Booking, BookingModel>();
            CreateMap<BookingModel, Booking>();

            CreateMap<Staff, StaffModel>();
            CreateMap<StaffModel, Staff>();

            CreateMap<Stopover, StopoverModel>();
            CreateMap<StopoverModel, Stopover>();

            CreateMap<Expense, ExpenseModel>();
            CreateMap<ExpenseModel, Expense>();

            CreateMap<Account, AccountModel>();
            CreateMap<AccountModel, Account>();

            CreateMap<Transaction, TransactionModel>();
            CreateMap<TransactionModel, Transaction>();

            CreateMap<Revenue, RevenueModel>();
            CreateMap<RevenueModel, Revenue>();

            CreateMap<CashTransaction, CashTransactionModel>();
            CreateMap<CashTransactionModel, CashTransaction>();

            CreateMap<CashRegister, CashRegisterModel>();
            CreateMap<CashRegisterModel, CashRegister>();
        }
    }
}