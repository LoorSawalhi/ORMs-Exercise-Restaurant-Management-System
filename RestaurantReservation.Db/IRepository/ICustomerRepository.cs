using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.ModelsDto;

namespace RestaurantReservation.Db.IRepository;

public interface ICustomerRepository
{
    Task<Customer> GetCustomerByIdAsync(int id);
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
    Task<List<CustomerDto>> CustomersByPartySize(int partySize);
}