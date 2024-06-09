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

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        var customer =  await _context.Customers.FindAsync(id);
        return customer == null ? null : _customerMapper.MapFromDbToDomain(customer);
    }

    public async Task<Customer?> GetCustomerByEmailAsync(string email)
    {
        var customer = await _context.Customers
            .Where(c => c.Email.Equals(email))
            .FirstOrDefaultAsync();
        return customer == null ? null : _customerMapper.MapFromDbToDomain(customer);
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
    
    public async void UpdateCustomerState(int customerId, Customer customer)
    {
        var customerDb = await _context.Customers.FindAsync(customerId);
        var mappedCustomer = _customerMapper.MapFromDomainToDb(customer);
    
        mappedCustomer.Id = customerDb.Id;

        _context.Entry(customerDb).CurrentValues.SetValues(mappedCustomer);
        _context.Entry(customerDb).State = EntityState.Modified;
        
    }


    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}