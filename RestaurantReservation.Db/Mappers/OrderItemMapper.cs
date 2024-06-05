using RestaurantsReservations.Domain.Models;
using Riok.Mapperly.Abstractions;
using OrderItem = RestaurantReservation.Db.Models.OrderItem;

namespace RestaurantReservation.Db.Mappers;

[Mapper]
public partial class OrderItemMapper
{
    public partial OrderItem MapFromDomainToDb(OrderItemDto orderItemDto);
    public partial OrderItemDto MapFromDbToDomain(OrderItem orderItem);

}