using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Mappers;
using RestaurantsReservations.Domain.IRepository;
using RestaurantsReservations.Domain.Models;

namespace RestaurantReservation.Db.Repositories;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly RestaurantReservationDbContext _context;
    private readonly MenuItemMapper _menuItemMapper;

    public MenuItemRepository(RestaurantReservationDbContext context, MenuItemMapper menuItemMapper)
    {
        _context = context;
        _menuItemMapper = menuItemMapper;
    }

    public async Task<MenuItem> GetMenuItemByIdAsync(int id)
    {
        
        var items =  await _context.MenuItems.FindAsync(id);
        return _menuItemMapper.MapFromDbToDomain(items);
    }

    public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
    {
        return await _context.MenuItems
            .Select( m => _menuItemMapper.MapFromDbToDomain(m))
            .ToListAsync();
    }

    public async Task AddMenuItemAsync(MenuItem menuItem)
    {
        var mappedItem = _menuItemMapper.MapFromDomainToDb(menuItem);
        await _context.MenuItems.AddAsync(mappedItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMenuItemAsync(MenuItem menuItem)
    {
        var mappedItem = _menuItemMapper.MapFromDomainToDb(menuItem);
        _context.MenuItems.Update(mappedItem);
        await _context.SaveChangesAsync();
    }
}