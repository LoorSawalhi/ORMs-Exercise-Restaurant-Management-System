using Riok.Mapperly.Abstractions;
using EmployeeDb = RestaurantReservation.Db.Models.Employee;
using EmployeeDomain = RestaurantsReservations.Domain.Models.Employee;
namespace RestaurantReservation.Db.Mappers;

[Mapper]
public partial class EmployeeMapper
{
    public partial EmployeeDb MapFromDomainToDb(EmployeeDomain employee);
    
    public partial EmployeeDomain MapFromDbToDomain(EmployeeDb employee);
}