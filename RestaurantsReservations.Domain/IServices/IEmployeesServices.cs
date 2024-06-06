using Microsoft.AspNetCore.Mvc;
using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.IServices;

public interface IEmployeesServices
{
    public Task<List<EmployeesView>> GetAllEmployees();
    public Task<Employee>? GetEmployee(string id);
    public Task<IEnumerable<Employee>> GetManagers();
    Task<decimal>? GetAverageOrderAmount(string employeeId);
}