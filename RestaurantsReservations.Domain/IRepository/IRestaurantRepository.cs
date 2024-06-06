using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.IRepository;

public interface IRestaurantRepository
{
    Task<Restaurant> GetRestaurantByIdAsync(int id);
    Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
    Task AddRestaurantAsync(Restaurant restaurant);
    Task UpdateRestaurantAsync(Restaurant restaurant);
    decimal CalculateRevenueById(int restaurantId);
}