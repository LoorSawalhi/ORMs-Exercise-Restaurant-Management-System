using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.IRepository;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly RestaurantReservationDbContext _context;

    public RestaurantRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<Restaurant> GetRestaurantByIdAsync(int id)
    {
        return await _context.Restaurants.FindAsync(id);
    }

    public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
    {
        return await _context.Restaurants.ToListAsync();
    }

    public async Task AddRestaurantAsync(Restaurant restaurant)
    {
        await _context.Restaurants.AddAsync(restaurant);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRestaurantAsync(Restaurant restaurant)
    {
        _context.Restaurants.Update(restaurant);
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