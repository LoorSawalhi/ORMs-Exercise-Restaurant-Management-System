using Microsoft.AspNetCore.Mvc;
using RestaurantsReservations.Domain.IRepository;
using RestaurantsReservations.Domain.IServices;
using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.Services;

public class EmployeeServices : IEmployeesServices
{
    private readonly IEmployeeRepository _employeeRepository;
    
    public EmployeeServices(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<List<EmployeesView>> GetAllEmployees()
    {
        return await _employeeRepository.GetEmployeesDetailedData();
    }

    public Task<Employee>? GetEmployee(string id)
    {
        return !int.TryParse(id, out var employeeId) ? null : _employeeRepository.GetEmployeeByIdAsync(employeeId);
    }

    public Task<IEnumerable<Employee>> GetManagers()
    {
        return _employeeRepository.ListEmployeesByPositionAsync("Manager");
    }

    public Task<decimal>? GetAverageOrderAmount(string employeeId)
    {
        return !int.TryParse(employeeId, out var id) ? null : _employeeRepository.CalculateAverageOrderAmount(id);
    }
}