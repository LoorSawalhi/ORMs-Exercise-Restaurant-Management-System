using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.IRepository;

public interface IRestaurantRepository
{
    Task<Restaurant> GetRestaurantByIdAsync(int id);
    Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
    Task AddRestaurantAsync(Restaurant restaurant);
    Task UpdateRestaurantAsync(Restaurant restaurant);
}