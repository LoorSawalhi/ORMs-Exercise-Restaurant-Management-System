using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.IRepository;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.ModelsDto;

namespace RestaurantReservation.Db.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly RestaurantReservationDbContext _context;

    public EmployeeRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public Task<List<EmployeeDto>> ListEmployeesByPositionAsync(string position)
    {
        return _context.Employees
            .Where(m => m.Position.Equals(position))
            .Select(e => new EmployeeDto(
                e.Id,
                e.FirstName,
                e.LastName,
                e.Position
                ))
            .ToListAsync();
    }

    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }
}