using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Mappers;
using RestaurantReservation.Db.ModelsDto;
using RestaurantsReservations.Domain.IRepository;
using RestaurantsReservations.Domain.Models;

namespace RestaurantReservation.Db.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly RestaurantReservationDbContext _context;
    private readonly ReservationsMapper _reservationsMapper;
    private readonly ReservationsViewMapper _reservationsViewMapper;
    private readonly OrderItemMapper _orderItemMapper;
    private readonly OrderDtoMapper _orderDtoMapper;

    public ReservationRepository(RestaurantReservationDbContext context,
        ReservationsMapper reservationsMapper,
        ReservationsViewMapper reservationsViewMapper,
        OrderItemMapper orderItemMapper,
        OrderDtoMapper orderDtoMapper)
    {
        _context = context;
        _reservationsMapper = reservationsMapper;
        _reservationsViewMapper = reservationsViewMapper;
        _orderItemMapper = orderItemMapper;
        _orderDtoMapper = orderDtoMapper;
    }

    public async Task<Reservation> GetReservationByIdAsync(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        return _reservationsMapper.MapFromDbToDomain(reservation);
    }

    public async Task<List<Reservation>> GetAllReservationsAsync()
    {
        return await _context.Reservations
            .Select(r => _reservationsMapper.MapFromDbToDomain(r))
            .ToListAsync();
    }

    public async Task<List<Reservation>> GetAllReservationsByCustomerIdAsync(int customerId)
    {
        return await _context.Reservations
            .Include(r => r.Restaurant)
            .Include(r => r.Customer)
            .Where(r => r.CustomerId == customerId)
            .Select(r => _reservationsMapper.MapFromDbToDomain(r))
            .ToListAsync();
    }

    public async Task AddReservationAsync(Reservation reservation)
    {
        var mapperReservation = _reservationsMapper.MapFromDomainToDb(reservation);
        await _context.Reservations.AddAsync(mapperReservation);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateReservationAsync(Reservation reservation)
    {
        var mapperReservation = _reservationsMapper.MapFromDomainToDb(reservation);
        _context.Reservations.Update(mapperReservation);
        await _context.SaveChangesAsync();
    }

    public async Task<List<OrderDto>> GetOrdersWithMenuItemsByReservationId(int reservationId)
    {
        return await _context.Reservations
            .Where(r => r.Id == reservationId)
            .Include(r => r.Orders)
            .ThenInclude(o => o.Items)
            .ThenInclude(i => i.MenuItem)
            .SelectMany(r => r.Orders)
            .Select(o => _orderDtoMapper.Map(o))
            .ToListAsync();
        // .Select(o => new OrderDto(
        //     o.Id,
        //     o.OrderDate,
        //     o.TotalAmount,
        //     o.EmployeeId,
        //     o.Items.Select(oi => new OrderItemDto(
        //         oi.Quantity,
        //         oi.MenuItem.Name,
        //         oi.MenuItem.Description
        //         )).ToList()
        //     )).ToListAsync();
    }

    public async Task<List<OrderItemDto>> GetMenuItemsByReservationId(int reservationId)
    {
        return await _context.Reservations
            .Where(r => r.Id == reservationId)
            .Include(r => r.Orders)
            .ThenInclude(o => o.Items)
            .ThenInclude(i => i.MenuItem)
            .SelectMany(r => r.Orders)
            .SelectMany(o => o.Items)
            .Select(o => _orderItemMapper.MapFromDbToDomain(o))
            .ToListAsync();
    }

    public async Task<List<ReservationsView>> GetReservationsView()
    {
        return await _context.ReservationsView
            .Select(r => _reservationsViewMapper.MapFromDbToDomain(r))
            .ToListAsync();
    }
}