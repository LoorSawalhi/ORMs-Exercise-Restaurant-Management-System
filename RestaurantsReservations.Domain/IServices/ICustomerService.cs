using Microsoft.AspNetCore.JsonPatch;
using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.IServices;

public interface ICustomerService
{
    public Task<Customer?>? GetCustomerById(string id);
    public Task<IEnumerable<Customer>> GetCustomers();
    public Task AddCustomer(Customer customer);
    Task UpdateCustomerAsync(string customerId, Customer customer);
}