using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Mappers;
using RestaurantsReservations.Domain.IRepository;
using RestaurantsReservations.Domain.Models;

namespace RestaurantReservation.Db.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly RestaurantReservationDbContext _context;
    private readonly RestaurantMapper _restaurantMapper;

    public RestaurantRepository(RestaurantReservationDbContext context,
        RestaurantMapper restaurantMapper)
    {
        _context = context;
        _restaurantMapper = restaurantMapper;
    }

    public async Task<Restaurant> GetRestaurantByIdAsync(int id)
    {
        var restaurant = await _context.Restaurants.FindAsync(id);
        return _restaurantMapper.MapFromDbToDomain(restaurant);
    }

    public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
    {
        return await _context.Restaurants
            .Select(r => _restaurantMapper.MapFromDbToDomain(r))
            .ToListAsync();
    }

    public async Task AddRestaurantAsync(Restaurant restaurant)
    {
        var mappedRestaurant = _restaurantMapper.MapFromDomainToDb(restaurant);
        await _context.Restaurants.AddAsync(mappedRestaurant);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRestaurantAsync(Restaurant restaurant)
    {
        var mappedRestaurant = _restaurantMapper.MapFromDomainToDb(restaurant);
        _context.Restaurants.Update(mappedRestaurant);
        await _context.SaveChangesAsync();
    }

    public decimal CalculateRevenueById(int restaurantId)
    {
        return _context.Restaurants
            .Where(r => r.Id == restaurantId)
            .Select(r => _context.TotalRevenueByRestaurantId(restaurantId))
            .FirstOrDefault();
    }
}