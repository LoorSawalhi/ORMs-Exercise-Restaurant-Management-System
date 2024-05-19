using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.IRepository;

public interface IReservationRepository
{
    Task<Reservation> GetReservationByIdAsync(int id);
    Task<List<Reservation>> GetAllReservationsAsync();
    Task<List<Reservation>> GetAllReservationsByCustomerIdAsync(int customerId);

    Task AddReservationAsync(Reservation reservation);
    Task UpdateReservationAsync(Reservation reservation);
    Task<List<Order>> GetOrdersWithMenuItemsByReservationId(int reservationId);
    Task<List<MenuItem>> GetMenuItemsByReservationId(int reservationId);
}