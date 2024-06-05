using Riok.Mapperly.Abstractions;
using EmployeesViewDb = RestaurantReservation.Db.Models.EmployeesView;
using EmployeesViewDomain = RestaurantsReservations.Domain.Models.EmployeesView;
namespace RestaurantReservation.Db.Mappers;

[Mapper]
public partial class EmployeesViewMapper
{
    public partial EmployeesViewDb MapFromDomainToDb(EmployeesViewDomain employee);
    
    public partial EmployeesViewDomain MapFromDbToDomain(EmployeesViewDb employee);
}