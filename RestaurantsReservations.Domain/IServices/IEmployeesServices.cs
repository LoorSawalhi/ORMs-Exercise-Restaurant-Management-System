using Microsoft.AspNetCore.Mvc;
using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.IServices;

public interface IEmployeesServices
{
    public Task<List<EmployeesView>> GetAllEmployees();
    public Task<IEnumerable<Employee>>? ListEmployeesForRestaurant(string restaurantId);
    public Task<Employee>? GetEmployee(string id);
    public Task<IEnumerable<Employee>> GetManagers();
    public Task<IEnumerable<Employee>>? ListManagersForRestaurant(string restaurantId);
    Task<decimal>? GetAverageOrderAmount(string employeeId);
    public Task AddEmployee(Employee employee, string restaurantId);
    Task UpdateEmployeeAsync(string employeeId, Employee employee);
}