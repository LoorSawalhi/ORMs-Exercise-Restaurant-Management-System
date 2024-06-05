using Riok.Mapperly.Abstractions;
using ReservationsViewDb = RestaurantReservation.Db.Models.ReservationsView;
using ReservationsViewDomain = RestaurantsReservations.Domain.Models.ReservationsView;

namespace RestaurantReservation.Db.Mappers;

[Mapper]
public partial class ReservationsViewMapper
{
    public partial ReservationsViewDb MapFromDomainToDb(ReservationsViewDomain reservation);
    public partial ReservationsViewDomain MapFromDbToDomain(ReservationsViewDb reservation);

}