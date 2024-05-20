using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.ModelsDto;

namespace RestaurantReservation.Db.IRepository;

public interface IReservationRepository
{
    Task<Reservation> GetReservationByIdAsync(int id);
    Task<List<Reservation>> GetAllReservationsAsync();
    Task<List<ReservationDto>> GetAllReservationsByCustomerIdAsync(int customerId);

    Task AddReservationAsync(Reservation reservation);
    Task UpdateReservationAsync(Reservation reservation);
    Task<List<OrderDto>> GetOrdersWithMenuItemsByReservationId(int reservationId);
    Task<List<OrderItemDto>> GetMenuItemsByReservationId(int reservationId);
}