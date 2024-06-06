using Microsoft.AspNetCore.Mvc;
using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.IRepository;

public interface IReservationRepository
{
    Task<Reservation> GetReservationByIdAsync(int id);
    Task<List<Reservation>> GetAllReservationsAsync();
    Task<List<Reservation>> GetAllReservationsByCustomerIdAsync(int customerId);

    Task AddReservationAsync(Reservation reservation);
    Task UpdateReservationAsync(Reservation reservation);
    Task<List<OrderDto>>? GetOrdersWithMenuItemsByReservationId(int reservationId);
    Task<List<OrderItemDto>> GetMenuItemsByReservationId(int reservationId);
    Task<List<ReservationsView>> GetReservationsView();
}