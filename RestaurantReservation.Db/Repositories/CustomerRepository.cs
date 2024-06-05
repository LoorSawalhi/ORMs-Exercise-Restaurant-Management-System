using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Mappers;
using RestaurantsReservations.Domain.IRepository;
using RestaurantsReservations.Domain.Models;

namespace RestaurantReservation.Db.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly RestaurantReservationDbContext _context;
    private readonly CustomerMapper _customerMapper;

    public CustomerRepository(RestaurantReservationDbContext context, CustomerMapper customerMapper)
    {
        _context = context;
        _customerMapper = customerMapper;
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        var customer =  await _context.Customers.FindAsync(id);
        return _customerMapper.MapFromDbToDomain(customer);
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        var customers = await _context.Customers.ToListAsync();
        return customers.Select( c => _customerMapper.MapFromDbToDomain(c));
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        var mappedCustomer = _customerMapper.MapFromDomainToDb(customer);
        await _context.Customers.AddAsync(mappedCustomer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        var mappedCustomer = _customerMapper.MapFromDomainToDb(customer);
        _context.Customers.Update(mappedCustomer);
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<Customer>> CustomersByPartySize(int partySize)
    {
        return await _context.Database.SqlQueryRaw<Customer>("FindCustomersByMinimumPartySize @p0", parameters: partySize)
            .ToListAsync();
    }
}