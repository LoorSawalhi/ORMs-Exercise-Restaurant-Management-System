using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.IRepository;

public interface ICustomerRepository
{
    Task<Customer?> GetCustomerByIdAsync(int id);
    Task<Customer?> GetCustomerByEmailAsync(string email);
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
    Task<List<Customer>> CustomersByPartySize(int partySize);
    void UpdateCustomerState(int customerId, Customer customer);
    Task SaveChangesAsync();
}