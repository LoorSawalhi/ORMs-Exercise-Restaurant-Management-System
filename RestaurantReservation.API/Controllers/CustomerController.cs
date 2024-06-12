using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestaurantsReservations.Domain.IServices;
using RestaurantsReservations.Domain.Models;

namespace RestaurantReservation.API.Controllers;

[ApiController]
// [Authorize]
[Route("api/v{version:apiVersion}/customers")]
[ApiVersion("1", Deprecated = true)]
[ApiVersion("2")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly ILogger<CustomerController> _logger;
    public CustomerController(ICustomerService customerService,
        ILogger<CustomerController> logger)
    {
        _customerService = customerService;
        _logger = logger;
    }
    /// <summary>
    /// Get all customers
    /// </summary>
    /// <response code="200">Returns all customers</response>
    [HttpGet(Name = "Get all customers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Customer>> GetCustomers()
    {
        // using var scope = _logger.BeginScope(new
        // {
        //     Class = "soso",
        // });
        //
        _logger.LogInformation("Getting all customers ...");
        var customers = await _customerService.GetCustomers();
        return Ok(customers);
    }
    
    /// <summary>
    /// Get a customer by id
    /// </summary>
    /// <param name="id">The id of the customer to get</param>
    /// <response code="200">Returns the requested customer</response>
    [HttpGet("{id}", Name = "Get a customer by his ID")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Customer>> GetCustomerById(string id)
    {
        var customer = await _customerService.GetCustomerById(id);

        if (customer != null) return Ok(customer);
        
        _logger.LogError($"Customer with id {id} does not exists!");
        return NotFound();

    }
    
    /// <summary>
    /// Add new customer
    /// </summary>
    /// <param name="customer">Customer object included in the request body</param>
    /// <response code="200">Adding the new customer</response>
    /// <response code="400">Customer is not valid</response>
    /// <response code="500">Internal server error</response>
    [HttpPost(Name = "Adding new customer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> AddNewCustomer(Customer customer)
    { 
        try
        {
            await _customerService.AddCustomer(customer);
            _logger.LogInformation($"New customer added successfully with email = {customer.Email}");
            return Ok("Customer added successfully.");
        }
        catch (FluentValidation.ValidationException ex)
        {
            var errors = ex.Errors.Select(e => new { Property = e.PropertyName, Error = e.ErrorMessage });
            return BadRequest(errors);
        }
        catch (Exception ex)
        {
            _logger.LogError("Server is not responding");
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
    
    /// <summary>
    /// Partially updating a customer
    /// </summary>
    /// <param name="customerId">Customer id who is going to be updated</param>
    /// <param name="patchDocument">Patch document containing the attribute to be updated</param>
    /// <response code="204">Updating the customer successfully</response>
    /// <response code="400">Invalid customer values, Not Updated!</response>
    /// <response code="404">Customer is not found</response>
    [HttpPatch("{customerId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> PartiallyUpdateCustomer(
        string customerId,
        JsonPatchDocument<Customer> patchDocument)
    {
        var customer = await _customerService.GetCustomerById(customerId);

        if (customer == null)
        {
            _logger.LogError($"Customer with id = {customerId} not found...");
            return NotFound();
        }


        patchDocument.ApplyTo(customer, ModelState);

        if (!ModelState.IsValid)
        {
            _logger.LogError($"Customer with id = {customerId} is not updated!");
            return BadRequest(ModelState);
        }

        if (!TryValidateModel(customer))
        {
            _logger.LogError($"Customer with id = {customerId} values are not valid ...");
            return BadRequest(ModelState);
        }

        await _customerService.UpdateCustomerAsync(customerId, customer);
        _logger.LogInformation($"Customer with id = {customerId} updated Successfully...");

        return NoContent();
    }
}