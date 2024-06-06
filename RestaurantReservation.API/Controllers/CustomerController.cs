using Microsoft.AspNetCore.Mvc;
using RestaurantsReservations.Domain.IServices;
using RestaurantsReservations.Domain.Models;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Customer>> GetCustomers()
    {
        var customers = await _customerService.GetCustomers();
        return Ok(customers);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomerById(string id)
    {
        var customer = await _customerService.GetCustomerById(id);

        if (customer == null)
            return BadRequest("Customer with id {id} does not exists!");
        
        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult> AddNewCustomer(Customer customer)
    { 
        try
        {
            await _customerService.AddCustomer(customer);
            return Ok("Customer added successfully.");
        }
        catch (FluentValidation.ValidationException ex)
        {
            var errors = ex.Errors.Select(e => new { Property = e.PropertyName, Error = e.ErrorMessage });
            return BadRequest(errors);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
}