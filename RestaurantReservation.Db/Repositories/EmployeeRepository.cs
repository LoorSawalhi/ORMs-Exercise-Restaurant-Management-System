using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Mappers;
using RestaurantsReservations.Domain.IRepository;
using RestaurantsReservations.Domain.Models;
using Order = RestaurantReservation.Db.Models.Order;

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
        var employees = await _context.Employees
            .Where(m => m.Position.Equals(position))
            .Select(c => _employeeMapper.MapFromDbToDomain(c))
            .ToListAsync();
            
    
        return employees;
    }

    public async Task<IEnumerable<Employee>>? ListEmployeesByPositionAndRestaurantAsync(string position, int restaurantId)
    {
        var employees = await _context.Employees
            .Where(m => m.Position.Equals(position) && m.RestaurantId.Equals(restaurantId))
            .Select(c => _employeeMapper.MapFromDbToDomain(c))
            .ToListAsync();
        return employees;
    }

    public async Task<decimal>? CalculateAverageOrderAmount(int employeeId)
    {
        var employee = await GetEmployeeByIdAsync(employeeId);
        if (employee == null)
            return -1;

        var orders = await _context.Employees
            .Where(e => e.Id == employeeId)
            .Include(e => e.Orders)
            .SelectMany(e => e.Orders)
            .Select(o => o.TotalAmount)
            .ToListAsync();
        
        return orders.DefaultIfEmpty(0).Average();
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
        
        return employee != null ? _employeeMapper.MapFromDbToDomain(employee) : null;
    }

    public async Task<Employee>? GetEmployeeByNameAsync(string firstName, string lastName)
    {
        var employee = await _context.Employees.Where(e =>
                e.FirstName.Equals(firstName)
                && e.LastName.Equals(lastName))
            .FirstOrDefaultAsync();

        return employee != null ? _employeeMapper.MapFromDbToDomain(employee) : null; }

    public async Task<IEnumerable<Employee>> GetEmployeeByRestaurantIdAsync(int id)
    {
        var employee =  await _context.Employees
            .Where(e => e.RestaurantId == id)
            .Select(e => _employeeMapper.MapFromDbToDomain(e))
            .ToListAsync();
        return employee;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _context.Employees
            .Select(e => _employeeMapper.MapFromDbToDomain(e))
            .ToListAsync();
    }

    public async Task AddEmployeeAsync(Employee employee, int restaurantId)
    {
        var mappedEmployee = _employeeMapper.MapFromDomainToDb(employee);
        mappedEmployee.RestaurantId = restaurantId;
        mappedEmployee.Orders = new List<Order>();
        await _context.Employees.AddAsync(mappedEmployee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        var mappedEmployee = _employeeMapper.MapFromDomainToDb(employee);
        _context.Employees.Update(mappedEmployee);
        await _context.SaveChangesAsync();
    }
    
    public async void UpdateEmployeeState(int employeeId, Employee employee)
    {
        var employeeDb = await _context.Customers.FindAsync(employeeId);
        var mappedEmployee = _employeeMapper.MapFromDomainToDb(employee);
    
        mappedEmployee.Id = employeeDb.Id;

        _context.Entry(employeeDb).CurrentValues.SetValues(mappedEmployee);
        _context.Entry(employeeDb).State = EntityState.Modified;
        
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}