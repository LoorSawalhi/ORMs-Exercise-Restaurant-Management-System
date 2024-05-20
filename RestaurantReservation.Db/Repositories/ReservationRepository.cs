using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.IRepository;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.ModelsDto;

namespace RestaurantReservation.Db.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly RestaurantReservationDbContext _context;

    public ReservationRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<Reservation> GetReservationByIdAsync(int id)
    {
        return await _context.Reservations.FindAsync(id);
    }

    public async Task<List<Reservation>> GetAllReservationsAsync()
    {
        return await _context.Reservations.ToListAsync();
    }

    public async Task<List<ReservationDto>> GetAllReservationsByCustomerIdAsync(int customerId)
    {
        return await _context.Reservations
            .Include(r => r.Restaurant)
            .Include(r => r.Customer)
            .Where(r => r.CustomerId == customerId)
            .Select(r => new ReservationDto(
                 r.Id,
                 r.ReservationDate,
                 r.PartySize,
                 r.Customer.FirstName,
                 r.TableId,
                 r.Restaurant.Name))
            .ToListAsync();
    }

    public async Task AddReservationAsync(Reservation reservation)
    {
        await _context.Reservations.AddAsync(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateReservationAsync(Reservation reservation)
    {
        _context.Reservations.Update(reservation);
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
            .Select(o => new OrderDto(
                o.Id,
                o.OrderDate,
                o.TotalAmount,
                o.EmployeeId,
                o.Items.Select(oi => new OrderItemDto(
                    oi.Quantity,
                    oi.MenuItem.Name,
                    oi.MenuItem.Description
                    )).ToList()
                )).ToListAsync();
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
            .Select(oi => new OrderItemDto(
                    oi.Quantity,
                    oi.MenuItem.Name,
                    oi.MenuItem.Description
                )).ToListAsync();
    }

    public async Task<List<ReservationsView>> GetReservationsView()
    {
        return await _context.ReservationsView
            .ToListAsync();
    }
}