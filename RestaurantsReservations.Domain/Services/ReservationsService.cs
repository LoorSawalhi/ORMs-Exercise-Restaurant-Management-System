using Microsoft.AspNetCore.Mvc;
using RestaurantsReservations.Domain.IRepository;
using RestaurantsReservations.Domain.IServices;
using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.Services;

public class ReservationsService : IReservationsService
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationsService(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public Task<List<Reservation>>? GetReservationsForRestaurants(string id)
    {
        return !int.TryParse(id, out var customerId) ? null : _reservationRepository.GetAllReservationsByCustomerIdAsync(customerId);
    }

    public Task<List<Reservation>>? GetReservationsForCustomer(string id)
    {
        return !int.TryParse(id, out var customerId) ? null : _reservationRepository.GetAllReservationsByCustomerIdAsync(customerId);
    }

    public Task<List<ReservationsView>> GetReservationsDetails()
    {
        return _reservationRepository.GetReservationsView();
    }

    public Task<List<OrderDto>>? GetReservationsOrdersByReservationId(string reservationId)
    {
        return !int.TryParse(reservationId, out var id) ? null : _reservationRepository.GetOrdersWithMenuItemsByReservationId(id);

    }

    public Task<List<OrderItemDto>>? GetOrderedMenuItemsForReservation(string reservationId)
    {
        return !int.TryParse(reservationId, out var id) ? null : _reservationRepository.GetMenuItemsByReservationId(id);
    }
}