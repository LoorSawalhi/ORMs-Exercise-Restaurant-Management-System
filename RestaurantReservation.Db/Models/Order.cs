using System.Runtime.InteropServices.JavaScript;

namespace RestaurantReservation.Db.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public Reservation Reservation { get; set; }
    public int ReservationId { get; set; }
    public Employee Employee { get; set; }
    public int EmployeeId { get; set; }
    public List<OrderItem> Items { get; set; }
}