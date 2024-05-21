using RestaurantReservation.Db.IRepository;

namespace RestaurantReservation.Service;

public class RestaurantService
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantService(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }

    public decimal CalculateTotalRevenue(int restaurantId)
    {
        return _restaurantRepository.CalculateRevenueById(restaurantId);
    }
}