using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.IRepository;

public interface IOrderRepository
{
    Task<Order> GetOrderByIdAsync(int id);
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task AddOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
}