using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.IRepository;

public interface ICustomerRepository
{
    Task<Customer> GetCustomerByIdAsync(int id);
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
    Task<List<Customer>> CustomersByPartySize(int partySize);
}