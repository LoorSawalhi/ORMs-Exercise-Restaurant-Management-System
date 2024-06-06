using Microsoft.AspNetCore.Mvc;
using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.IServices;

public interface IReservationsService
{
    public Task<List<Reservation>>? GetReservationsForRestaurants(string id);
    public Task<List<Reservation>>? GetReservationsForCustomer(string id);
    public Task<List<ReservationsView>> GetReservationsDetails();
    Task<List<OrderDto>>? GetReservationsOrdersByReservationId(string reservationId);
    Task<List<OrderItemDto>>? GetOrderedMenuItemsForReservation(string reservationId);
}