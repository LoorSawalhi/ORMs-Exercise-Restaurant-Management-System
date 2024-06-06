using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Mappers;
using RestaurantReservation.Db.Repositories;
using RestaurantsReservations.Domain.IRepository;
using RestaurantsReservations.Domain.IServices;
using RestaurantsReservations.Domain.Services;
using RestaurantsReservations.Domain.Validators;
using FluentValidation;
using RestaurantsReservations.Domain.Models;

namespace RestaurantReservation.API;

public static class ServiceConfiguration
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RestaurantReservationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CustomerValidator>();
        // services.AddSingleton<IValidator<Customer>, CustomerValidator>();
        return services;
    }
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IEmployeesServices, EmployeeServices>();
        services.AddScoped<IReservationsService, ReservationsService>();
        
        return services;
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IMenuItemRepository, MenuItemRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        services.AddScoped<ITableRepository, TableRepository>();
       
        return services;
    }
    
    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        services.AddScoped<CustomerMapper>();
        services.AddScoped<EmployeeMapper>();
        services.AddScoped<EmployeesViewMapper>();
        services.AddScoped<MenuItemMapper>();
        services.AddScoped<OrderDtoMapper>();
        services.AddScoped<OrderItemMapper>();
        services.AddScoped<OrderMapper>();
        services.AddScoped<ReservationsMapper>();
        services.AddScoped<ReservationsViewMapper>();
        services.AddScoped<RestaurantMapper>();
        services.AddScoped<TableMapper>();

        return services;
    }
}