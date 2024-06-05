using Riok.Mapperly.Abstractions;
using CustomerDomain = RestaurantsReservations.Domain.Models.Customer;
using CustomerDb = RestaurantReservation.Db.Models.Customer;
namespace RestaurantReservation.Db.Mappers;

[Mapper]
public partial class CustomerMapper
{
    public partial CustomerDomain MapFromDbToDomain(CustomerDb customer);
    public partial CustomerDb MapFromDomainToDb(CustomerDomain customer);

}