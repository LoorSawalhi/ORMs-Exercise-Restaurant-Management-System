using RestaurantsReservations.Domain.Models;

namespace RestaurantsReservations.Domain.IRepository;

public interface ITableRepository
{
    Task<Table> GetTableByIdAsync(int id);
    Task<IEnumerable<Table>> GetAllTablesAsync();
    Task AddTableAsync(Table table);
    Task UpdateTableAsync(Table table);
}