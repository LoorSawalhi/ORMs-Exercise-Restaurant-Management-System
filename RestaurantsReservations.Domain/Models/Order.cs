namespace RestaurantsReservations.Domain.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public int ReservationId { get; set; }
    public int EmployeeId { get; set; }
}