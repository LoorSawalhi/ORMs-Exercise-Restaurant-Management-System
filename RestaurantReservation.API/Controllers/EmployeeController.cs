using Microsoft.AspNetCore.Mvc;
using RestaurantsReservations.Domain.IServices;
using RestaurantsReservations.Domain.Models;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("employees")]
public class EmployeeController: ControllerBase
{
    private readonly IEmployeesServices _employeesServices;

    public EmployeeController(IEmployeesServices employeesServices)
    {
        _employeesServices = employeesServices;
    }
    
    [HttpGet]
    public async Task<ActionResult<Employee>> GetEmployees()
    {
        var employees = await _employeesServices.GetAllEmployees();
        return Ok(employees);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GeEmployeeById(string id)
    {
        var employee = await _employeesServices.GetEmployee(id);

        if (employee == null)
            return BadRequest("Employee with id {id} does not exists!");
        
        return Ok(employee);
    }
    
    [HttpGet("managers")]
    public async Task<ActionResult<Employee>> GetManagers()
    {
        var employees = await _employeesServices.GetManagers();
        return Ok(employees);
    }
    
    [HttpGet("{employeeId}/average-order-amount")]
    public async Task<ActionResult<Employee>> CalculateAverageOrderAmountForEmployee(string employeeId)
    {
        var employees = await _employeesServices.GetAverageOrderAmount(employeeId);
        return Ok(employees);
    }
    
    
}