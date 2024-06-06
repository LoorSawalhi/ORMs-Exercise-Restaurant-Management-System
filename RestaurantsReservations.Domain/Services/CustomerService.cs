using FluentValidation;
using FluentValidation.Results;
using RestaurantsReservations.Domain.IRepository;
using RestaurantsReservations.Domain.IServices;
using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IValidator<Customer> _validator;
    
    public CustomerService(ICustomerRepository customerRepository, IValidator<Customer> validator)
    {
        _customerRepository = customerRepository;
        _validator = validator;
    }

    public Task<Customer>? GetCustomerById(string id)
    {
        return !int.TryParse(id, out var customerId) ? null : _customerRepository.GetCustomerByIdAsync(customerId);
    }

    public async Task<IEnumerable<Customer>> GetCustomers()
    {
        return await _customerRepository.GetAllCustomersAsync();
    }

    public async Task AddCustomer(Customer customer)
    {
        await _validator.ValidateAndThrowAsync(customer);
        await _customerRepository.AddCustomerAsync(customer);
    }
}