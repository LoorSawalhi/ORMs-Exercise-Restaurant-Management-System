using Microsoft.AspNetCore.Mvc;
using RestaurantsReservations.Domain.IServices;
using RestaurantsReservations.Domain.Models;

namespace RestaurantReservation.API.Controllers;

[ApiController]
[Route("reservations")]
public class ReservationsController : ControllerBase
{
    private readonly IReservationsService _reservationsService;

    public ReservationsController(IReservationsService reservationsService)
    {
        _reservationsService = reservationsService;
    }
    
    [HttpGet]
    public async Task<ActionResult<Reservation>>  AllReservations()
    {
        var employees = await _reservationsService.GetReservationsDetails();
        return Ok(employees);
    }
    
    [HttpGet("customers/{customerId}")]
    public async Task<ActionResult<Reservation>>  RetrieveReservationsByCustomerID(string customerId)
    {
        var employees = await _reservationsService.GetReservationsForCustomer(customerId);
        return Ok(employees);
    }
    
    [HttpGet("{reservationId}/orders")]
    public async Task<ActionResult<OrderDto>> ListOrdersAndMenuItemsForReservation(string reservationId)
    {
        var employees = await _reservationsService.GetReservationsOrdersByReservationId(reservationId);
        return Ok(employees);
    }
    
    [HttpGet("{reservationId}/menu-items")]
    public async Task<ActionResult<Reservation>> ListOrderedMenuItemsForReservation(string reservationId)
    {
        var employees = await _reservationsService.GetOrderedMenuItemsForReservation(reservationId);
        return Ok(employees);
    }
    
}