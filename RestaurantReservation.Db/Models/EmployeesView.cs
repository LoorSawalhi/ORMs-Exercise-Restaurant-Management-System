namespace RestaurantReservation.Db.Models;

public record EmployeesView
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public string RestaurantName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string OpeningHours { get; set; }
}