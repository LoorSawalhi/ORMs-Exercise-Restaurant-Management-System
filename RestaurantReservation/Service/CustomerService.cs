using RestaurantReservation.Db.IRepository;
using RestaurantReservation.Db.ModelsDto;

namespace RestaurantReservation.Service;

public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<CustomerDto>> GetCustomersByPartySize(int partySize)
    {
        return await _customerRepository.CustomersByPartySize(partySize);
    }
}