using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.IRepository;

public interface ITableRepository
{
    Task<Table> GetTableByIdAsync(int id);
    Task<IEnumerable<Table>> GetAllTablesAsync();
    Task AddTableAsync(Table table);
    Task UpdateTableAsync(Table table);
}