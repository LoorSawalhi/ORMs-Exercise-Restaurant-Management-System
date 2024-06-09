using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.IRepository;

public interface IEmployeeRepository
{
    Task<Employee>? GetEmployeeByIdAsync(int id);
    Task<Employee>? GetEmployeeByNameAsync(string firstName, string lastName);
    Task<IEnumerable<Employee>> GetEmployeeByRestaurantIdAsync(int id);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task AddEmployeeAsync(Employee employee, int restaurantId);
    Task UpdateEmployeeAsync(Employee employee);
    Task<IEnumerable<Employee>> ListEmployeesByPositionAsync(string position);
    Task<IEnumerable<Employee>>? ListEmployeesByPositionAndRestaurantAsync(string position, int restaurantId);

    Task<decimal>? CalculateAverageOrderAmount(int employeeId);
    Task<List<EmployeesView>> GetEmployeesDetailedData();
    void UpdateEmployeeState(int employeeId, Employee employee);
    Task SaveChangesAsync();
}