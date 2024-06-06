using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.IServices;

public interface ICustomerService
{
    public Task<Customer>? GetCustomerById(string id);
    public Task<IEnumerable<Customer>> GetCustomers();
    public Task AddCustomer(Customer customer);
}