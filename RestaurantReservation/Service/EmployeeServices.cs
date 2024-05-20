using RestaurantReservation.Db.IRepository;
using RestaurantReservation.Db.ModelsDto;

namespace RestaurantReservation.Service;

public class EmployeeServices
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeServices(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<List<EmployeeDto>> GetAllManagers()
    {
        return await _employeeRepository.ListEmployeesByPositionAsync("manager");
    }
}