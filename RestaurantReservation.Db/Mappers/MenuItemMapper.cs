using Riok.Mapperly.Abstractions;
using MenuItemDb = RestaurantReservation.Db.Models.MenuItem;
using MenuItemDomain = RestaurantsReservations.Domain.Models.MenuItem;

namespace RestaurantReservation.Db.Mappers;

[Mapper]
public partial class MenuItemMapper
{
    public partial MenuItemDb MapFromDomainToDb(MenuItemDomain menuItem);
    
    public partial MenuItemDomain MapFromDbToDomain(MenuItemDb menuItem);
}