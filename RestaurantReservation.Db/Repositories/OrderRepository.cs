using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Data;
using RestaurantReservation.Db.Mappers;
using RestaurantsReservations.Domain.IRepository;
using RestaurantsReservations.Domain.Models;

namespace RestaurantReservation.Db.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly RestaurantReservationDbContext _context;
    private readonly OrderMapper _orderMapper;

    public OrderRepository(RestaurantReservationDbContext context, OrderMapper orderMapper)
    {
        _context = context;
        _orderMapper = orderMapper;
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        return _orderMapper.MapFromDbToDomain(order);
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _context.Orders
            .Select(o => _orderMapper.MapFromDbToDomain(o))
            .ToListAsync();
    }

    public async Task AddOrderAsync(Order order)
    {
        var mappedOrder = _orderMapper.MapFromDomainToDb(order);
        await _context.Orders.AddAsync(mappedOrder);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteByIdsAsync(IEnumerable<int> ids)
    {
        var i =  _context.Orders.Where(o => ids.Contains(o.Id)).AsQueryable();
        _context.Orders.RemoveRange(i);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateOrderAsync(Order order)
    {
        var mappedOrder = _orderMapper.MapFromDomainToDb(order);
        _context.Orders.Update(mappedOrder);
        await _context.SaveChangesAsync();
    }
}