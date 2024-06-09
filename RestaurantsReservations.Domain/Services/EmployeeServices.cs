using FluentValidation;
using RestaurantsReservations.Domain.Customized_Exceptions;
using RestaurantsReservations.Domain.IRepository;
using RestaurantsReservations.Domain.IServices;
using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.Services;

public class EmployeeServices : IEmployeesServices
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IValidator<Employee> _validator;

    
    public EmployeeServices(IEmployeeRepository employeeRepository,
        IRestaurantRepository restaurantRepository,
        IValidator<Employee> validator)
    {
        _employeeRepository = employeeRepository;
        _restaurantRepository = restaurantRepository;
        _validator = validator;
    }

    public async Task<List<EmployeesView>> GetAllEmployees()
    {
        return await _employeeRepository.GetEmployeesDetailedData();
    }

    public Task<IEnumerable<Employee>>? ListEmployeesForRestaurant(string restaurantId)
    {
        return !int.TryParse(restaurantId, out var id) ? throw new InvalidDataException()
            : _employeeRepository.GetEmployeeByRestaurantIdAsync(id);

    }

    public Task<Employee>? GetEmployee(string id)
    {
        return !int.TryParse(id, out var employeeId) ? throw new InvalidDataException()
            : _employeeRepository.GetEmployeeByIdAsync(employeeId);
    }

    public Task<IEnumerable<Employee>> GetManagers()
    {
        return _employeeRepository.ListEmployeesByPositionAsync("Manager");
    }

    public Task<IEnumerable<Employee>>? ListManagersForRestaurant(string restaurantId)
    {
        return !int.TryParse(restaurantId, out var id) ? throw new InvalidDataException()
            : _employeeRepository.ListEmployeesByPositionAndRestaurantAsync("Manager", id);
    }

    public Task<decimal>? GetAverageOrderAmount(string employeeId)
    {
        return !int.TryParse(employeeId, out var id) ? throw new InvalidDataException() :
            _employeeRepository.CalculateAverageOrderAmount(id);
    }

    public async Task AddEmployee(Employee employee, string restaurantId)
    {
        var restaurant = !int.TryParse(restaurantId, out var id) ? throw new InvalidDataException() :
            await _restaurantRepository.GetRestaurantByIdAsync(id);

        if (restaurant == null)
            throw new RestaurantDoesNotExists();
        
        await _validator.ValidateAndThrowAsync(employee);
        var employeeDb = await _employeeRepository.GetEmployeeByNameAsync(employee.FirstName, employee.LastName);
        if (employeeDb == null)
            await _employeeRepository.AddEmployeeAsync(employee, restaurant.Id);
        else
            throw new EmployeeAlreadyExistsException();
    }

    public async Task UpdateEmployeeAsync(string employeeId, Employee employee)
    {
        if (int.TryParse(employeeId, out var id))
        {
            _employeeRepository.UpdateEmployeeState(id, employee);
            await _employeeRepository.SaveChangesAsync();
        }
        else
        {
            throw new InvalidDataException();
        }
    }
}