using RestaurantReservation.Db.ModelsDto;
using RestaurantsReservations.Domain.Models;
using Order = RestaurantReservation.Db.Models.Order;
using OrderItem = RestaurantReservation.Db.Models.OrderItem;

namespace RestaurantReservation.Db.Mappers;

using Riok.Mapperly.Abstractions;

[Mapper]
public partial class OrderDtoMapper
{
    public partial OrderDto Map(Order order);
    
    public partial OrderItemDto MapOrderItem(OrderItem item);
}
