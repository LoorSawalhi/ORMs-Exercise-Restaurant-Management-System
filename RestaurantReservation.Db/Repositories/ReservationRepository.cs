using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.IRepository;
using RestaurantReservation.Db.Models;

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

    public async Task<List<Reservation>> GetAllReservationsByCustomerIdAsync(int customerId)
    {
        return await _context.Reservations.Where(r => r.CustomerId == customerId).ToListAsync();
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

    public async Task<List<Order>> GetOrdersWithMenuItemsByReservationId(int reservationId)
    {
        return await _context.Orders
            .Include(o => o.Items)
            .Where(o => o.ReservationId == reservationId)
            .ToListAsync();
    }

    public async Task<List<MenuItem>> GetMenuItemsByReservationId(int reservationId)
    {
        return await _context.MenuItems
            .Include(m => m.Orders.Where(o => o.ReservationId == reservationId))
            .ToListAsync();
    }
}