using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.IRepository;

public interface IEmployeeRepository
{
    Task<Employee>? GetEmployeeByIdAsync(int id);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task AddEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employee);
    Task<IEnumerable<Employee>> ListEmployeesByPositionAsync(string position);
    Task<decimal>? CalculateAverageOrderAmount(int employeeId);
    Task<List<EmployeesView>> GetEmployeesDetailedData();
}