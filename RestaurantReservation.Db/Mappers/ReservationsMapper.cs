using Riok.Mapperly.Abstractions;
using ReservationsDb = RestaurantReservation.Db.Models.Reservation;
using ReservationsModel = RestaurantsReservations.Domain.Models.Reservation;

namespace RestaurantReservation.Db.Mappers;

[Mapper]
public partial class ReservationsMapper
{
    public partial ReservationsDb MapFromDomainToDb(ReservationsModel reservation);
    
    public partial ReservationsModel MapFromDbToDomain(ReservationsDb reservation);
}