using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.ModelsDto;

namespace RestaurantReservation.Db.IRepository;

public interface IEmployeeRepository
{
    Task<Employee> GetEmployeeByIdAsync(int id);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task AddEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employee);
    Task<List<EmployeeDto>> ListEmployeesByPositionAsync(string position);
    Task<decimal> CalculateAverageOrderAmount(int employeeId);
    Task<List<EmployeesView>> GetEmployeesDetailedData();
}
