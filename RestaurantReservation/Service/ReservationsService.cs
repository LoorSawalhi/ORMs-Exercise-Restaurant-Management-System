using RestaurantReservation.Db.IRepository;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.ModelsDto;

namespace RestaurantReservation.Service;

public class ReservationsService
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationsService(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<List<ReservationDto>> GetReservationsByCustomer(int customerId)
    {
        return await _reservationRepository.GetAllReservationsByCustomerIdAsync(customerId);
    }

    public async Task<List<OrderDto>> ListOrdersAndMenuItems(int reservationId)
    {
        return await _reservationRepository.GetOrdersWithMenuItemsByReservationId(reservationId);
    }
}