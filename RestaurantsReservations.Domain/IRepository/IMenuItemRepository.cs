using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.IRepository;

public interface IMenuItemRepository
{
    Task<MenuItem> GetMenuItemByIdAsync(int id);
    Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
    Task AddMenuItemAsync(MenuItem menuItem);
    Task UpdateMenuItemAsync(MenuItem menuItem);
}