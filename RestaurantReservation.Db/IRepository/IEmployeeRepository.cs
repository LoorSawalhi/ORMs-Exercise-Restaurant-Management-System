using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.IRepository;

public interface IEmployeeRepository
{
    Task<Employee> GetEmployeeByIdAsync(int id);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task AddEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employee);
    public Task<List<Employee>> ListEmployeesByPositionAsync(string position);
}
