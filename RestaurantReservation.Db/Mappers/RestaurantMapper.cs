using Riok.Mapperly.Abstractions;
using RestaurantDb = RestaurantReservation.Db.Models.Restaurant;
using RestaurantDomain = RestaurantsReservations.Domain.Models.Restaurant;

namespace RestaurantReservation.Db.Mappers;

[Mapper]
public partial class RestaurantMapper
{
    public partial RestaurantDb MapFromDomainToDb(RestaurantDomain restaurant);
    public partial RestaurantDomain MapFromDbToDomain(RestaurantDb restaurant);

}