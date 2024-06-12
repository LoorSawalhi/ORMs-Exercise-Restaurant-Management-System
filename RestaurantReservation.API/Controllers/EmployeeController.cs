using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestaurantsReservations.Domain.Customized_Exceptions;
using RestaurantsReservations.Domain.IServices;
using RestaurantsReservations.Domain.Models;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/employees")]
[ApiVersion("2")]
public class EmployeeController: ControllerBase
{
    private readonly IEmployeesServices _employeesServices;
    private readonly ILogger<EmployeeController> _logger;


    public EmployeeController(IEmployeesServices employeesServices,
        ILogger<EmployeeController> logger)
    {
        _employeesServices = employeesServices;
        _logger = logger;
    }
    
    /// <summary>
    /// Get all employees
    /// </summary>
    /// <response code="200">Returns all employees</response>
    /// <response code="204">No available employees</response>

    [HttpGet(Name = "Get all employees")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<Employee>> GetEmployees()
    {
        var employees = await _employeesServices.GetAllEmployees(); 
        if (employees.Count == 0)
        {
            _logger.LogInformation($"No available employees");
            return NoContent();
        }
        _logger.LogInformation("Getting all employees");

        return Ok(employees);
    }
    
    /// <summary>
    /// Get all employees for a restaurant
    /// </summary>
    ///  <param name="restaurantId">The id of the restaurant to get employees of</param>
    /// <response code="200">Returns all employees</response>
    /// <response code="204">No available employees</response>
    /// <response code="400">Bad restaurant id</response>

    [HttpGet("restaurants/{restaurantId}",Name = "Get all employees for a restaurant")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Employee>> GetEmployeesForRestaurant(string restaurantId)
    {
        try
        {
            var employees = await _employeesServices.ListEmployeesForRestaurant(restaurantId);
            if (employees.ToList().Count == 0)
            {
                _logger.LogInformation($"No available employees for restaurant {restaurantId}");
                return NoContent();
            }
            _logger.LogInformation($"Getting all employees for restaurant with id {restaurantId}");

            return Ok(employees);
        } catch (InvalidDataException e)
        {
            _logger.LogError($"Restaurant id {restaurantId} is not valid");
            return BadRequest($"Bad restaurant id");   
        }
       
    }
    
    /// <summary>
    /// Get an employee by id
    /// </summary>
    /// <param name="id">The id of the employee to get</param>
    /// <response code="200">Returns the requested employee</response>
    ///<response code="400">Employee id is not valid</response>
    /// <response code="401">Employee not found</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Customer>> GeEmployeeById(string id)
    {
        try
        {
            var employee = await _employeesServices.GetEmployee(id);

            if (employee != null) return Ok(employee);
            _logger.LogError($"Employee with id {id} does not exists!");

            return NotFound($"Employee with id {id} does not exists!");
        } catch (InvalidDataException e)
        {
            _logger.LogError($"Employee id {id} is not valid");
            return BadRequest($"Bad restaurant id");   
        }

    }
    
    /// <summary>
    /// Get all managers
    /// </summary>
    /// <response code="200">Returns all managers</response>
    /// <response code="204">No available managers</response>
    [HttpGet("managers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<Employee>> GetManagers()
    {
        var employees = await _employeesServices.GetManagers();
        if (employees.ToList().Count == 0)
        {
            _logger.LogInformation($"No available managers");
            return NoContent();
        }
        _logger.LogInformation("Getting all managers ...");
        return Ok(employees);
    }
    
    /// <summary>
    /// Get all managers for a restaurant
    /// </summary>
    /// <response code="200">Returns all managers</response>
    /// <response code="204">Restaurant id has no managers</response>
    /// <response code="401">Restaurant not found</response>
    [HttpGet("restaurants/{restaurantId}/managers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Employee>> GetManagersForRestaurant(string restaurantId)
    {
        try
        {
            var employees = await _employeesServices.ListManagersForRestaurant(restaurantId);
            if (employees.ToList().Count == 0)
            {
                _logger.LogInformation($"No available managers for restaurant with id {restaurantId}...");
                return NoContent();
            }
            _logger.LogInformation($"Getting all managers for restaurant with id {restaurantId}...");
            return Ok(employees);
        }
        catch (InvalidDataException e)
        {
            _logger.LogError($"Restaurant id {restaurantId} is not valid");
            return BadRequest($"Bad restaurant id");   
        }
    }
    
    /// <summary>
    /// Calculate the average order amount for an employee
    /// </summary>
    /// <param name="employeeId"> Id of the employee to calculate orders amount</param>
    /// <returns></returns>
    [HttpGet("{employeeId}/average-order-amount")]
    public async Task<ActionResult<Employee>> CalculateAverageOrderAmountForEmployee(string employeeId)
    {
        try
        {
            var average = await _employeesServices.GetAverageOrderAmount(employeeId);

            if (average == null)
            {
                _logger.LogInformation($"No available orders for employee with id {employeeId}...");
                return NoContent();
            }

            if (average != -1) return Ok(average);
            
            _logger.LogError($"Employee with id {employeeId} does not exists");
            return BadRequest("Employee does not exists!");
            
        }  catch (InvalidDataException e) {
            _logger.LogError($"Employee id {employeeId} is not valid");
            return BadRequest("Bad employee id");   
        }
    }

    /// <summary>
    /// Add new employee
    /// </summary>
    /// <param name="employee">Employee object included in the request body</param>
    /// <param name="restaurantId">Id for the restaurant an employee should be added to</param>
    /// <response code="200">Adding the new employee</response>
    /// <response code="400">Employee is not valid</response>
    /// <response code="500">Internal server error</response>
    [HttpPost("{restaurantId}",Name = "Adding new employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> AddNewEmployee(string restaurantId, Employee employee)
    {
        try
        {
            await _employeesServices.AddEmployee(employee, restaurantId);
            _logger.LogInformation(
                $"New employee added successfully with name = {employee.FirstName} {employee.LastName}");
            return Ok("Employee added successfully.");
        }
        catch (FluentValidation.ValidationException ex)
        {
            var errors = ex.Errors.Select(e => new { Property = e.PropertyName, Error = e.ErrorMessage });
            return BadRequest(errors);
        }
        catch (EmployeeAlreadyExistsException ex)
        {
            _logger.LogError($"Employee with name = {employee.FirstName} {employee.LastName} already exists");
            return BadRequest("Employee already exists");
        }
        catch (RestaurantDoesNotExists ex)
        {
            _logger.LogError($"Restaurant with id = {restaurantId}does not exists");
            return BadRequest("No such restaurant");
        }
        catch (Exception ex)
        {
            _logger.LogError("Server is not responding");
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
    
    /// <summary>
    /// Partially updating an employee
    /// </summary>
    /// <param name="employeeId">Employee id who is going to be updated</param>
    /// <param name="patchDocument">Patch document containing the attribute to be updated</param>
    /// <response code="204">Updating the employee successfully</response>
    /// <response code="400">Invalid employee values, Not Updated!</response>
    /// <response code="404">Employee is not found</response>
    [HttpPatch("{employeeId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> PartiallyUpdateCustomer(
        string employeeId,
        JsonPatchDocument<Employee> patchDocument)
    {
        var employee = await _employeesServices.GetEmployee(employeeId);

        if (employee == null)
        {
            _logger.LogError($"Employee with id = {employeeId} not found...");
            return NotFound();
        }
        
        patchDocument.ApplyTo(employee, ModelState);

        if (!ModelState.IsValid)
        {
            _logger.LogError($"Employee with id = {employeeId} is not updated!");
            return BadRequest(ModelState);
        }

        if (!TryValidateModel(employee))
        {
            _logger.LogError($"Employee with id = {employeeId} values are not valid ...");
            return BadRequest(ModelState);
        }

        await _employeesServices.UpdateEmployeeAsync(employeeId, employee);
        _logger.LogInformation($"Employee with id = {employeeId} updated Successfully...");

        return NoContent();
    }
}