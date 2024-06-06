using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.IRepository;

public interface IMenuItemRepository
{
    Task<MenuItem> GetMenuItemByIdAsync(int id);
    Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
    Task AddMenuItemAsync(MenuItem menuItem);
    Task UpdateMenuItemAsync(MenuItem menuItem);
}