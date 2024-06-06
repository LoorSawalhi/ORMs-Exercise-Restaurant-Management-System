namespace RestaurantsReservations.Domain.Models;

public class Table
{
    public int Id { get; set; }
    public int Capacity { get; set; }
    public int RestaurantId { get; set; }
}