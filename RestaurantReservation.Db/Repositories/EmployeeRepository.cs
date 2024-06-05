using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Mappers;
using RestaurantsReservations.Domain.IRepository;
using RestaurantsReservations.Domain.Models;

namespace RestaurantReservation.Db.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly RestaurantReservationDbContext _context;
    private readonly EmployeeMapper _employeeMapper;
    private readonly EmployeesViewMapper _employeesViewMapper;
    public EmployeeRepository(RestaurantReservationDbContext context, EmployeeMapper employeeMapper, EmployeesViewMapper employeesView)
    {
        _context = context;
        _employeeMapper = employeeMapper;
        _employeesViewMapper = employeesView;
    }

    public async Task<IEnumerable<Employee>> ListEmployeesByPositionAsync(string position)
    {
        var employees = _context.Employees
            .Where(m => m.Position.Equals(position))
            .Select(c => _employeeMapper.MapFromDbToDomain(c));
            
    
        return employees;
    }

    public async Task<decimal> CalculateAverageOrderAmount(int employeeId)
    {
        return await _context.Employees
            .Where(e => e.Id == employeeId)
            .Include(e => e.Orders)
            .SelectMany(e => e.Orders)
            .Select(o => o.TotalAmount)
            .SumAsync();
    }

    public async Task<List<EmployeesView>> GetEmployeesDetailedData()
    {
        return await _context.EmployeesView
            .Select(e => _employeesViewMapper.MapFromDbToDomain(e))
                 .ToListAsync();
    }

    public async Task<Employee>? GetEmployeeByIdAsync(int id)
    {
        var employee =  await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == id);
        return _employeeMapper.MapFromDbToDomain(employee);
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _context.Employees
            .Select(e => _employeeMapper.MapFromDbToDomain(e))
            .ToListAsync();
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        var mappedEmployee = _employeeMapper.MapFromDomainToDb(employee);
        await _context.Employees.AddAsync(mappedEmployee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        var mappedEmployee = _employeeMapper.MapFromDomainToDb(employee);
        _context.Employees.Update(mappedEmployee);
        await _context.SaveChangesAsync();
    }
}