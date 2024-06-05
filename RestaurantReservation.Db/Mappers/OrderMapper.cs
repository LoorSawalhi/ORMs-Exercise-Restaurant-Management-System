using Riok.Mapperly.Abstractions;
using OrderDb = RestaurantReservation.Db.Models.Order;
using OrderModel = RestaurantsReservations.Domain.Models.Order;

namespace RestaurantReservation.Db.Mappers;

[Mapper]
public partial class OrderMapper
{
    public partial OrderDb MapFromDomainToDb(OrderModel order);
    
    public partial OrderModel MapFromDbToDomain(OrderDb order);
}