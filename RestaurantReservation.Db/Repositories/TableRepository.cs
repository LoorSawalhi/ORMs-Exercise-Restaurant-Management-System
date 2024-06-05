using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Mappers;
using RestaurantsReservations.Domain.IRepository;
using RestaurantsReservations.Domain.Models;

namespace RestaurantReservation.Db.Repositories;

public class TableRepository : ITableRepository
{
    private readonly RestaurantReservationDbContext _context;
    private readonly TableMapper _tableMapper;

    public TableRepository(RestaurantReservationDbContext context, TableMapper tableMapper)
    {
        _context = context;
        _tableMapper = tableMapper;
    }

    public async Task<Table> GetTableByIdAsync(int id)
    {
        var table = await _context.Tables.FindAsync(id);
        return _tableMapper.MapFromDbToDomain(table);
    }

    public async Task<IEnumerable<Table>> GetAllTablesAsync()
    {
        return await _context.Tables
            .Select(t => _tableMapper.MapFromDbToDomain(t))
            .ToListAsync();

    }

    public async Task AddTableAsync(Table table)
    {
        var mappedTable = _tableMapper.MapFromDomainToDb(table);
        await _context.Tables.AddAsync(mappedTable);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTableAsync(Table table)
    {
        var mappedTable = _tableMapper.MapFromDomainToDb(table);
        _context.Tables.Update(mappedTable);
        await _context.SaveChangesAsync();
    }
}