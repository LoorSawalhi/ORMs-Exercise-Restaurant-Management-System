using Riok.Mapperly.Abstractions;
using TableDb = RestaurantReservation.Db.Models.Table;
using TableDomain = RestaurantsReservations.Domain.Models.Table;

namespace RestaurantReservation.Db.Mappers;

[Mapper]
public partial class TableMapper
{
    public partial TableDb MapFromDomainToDb(TableDomain table);
    public partial TableDomain MapFromDbToDomain(TableDb table);

}