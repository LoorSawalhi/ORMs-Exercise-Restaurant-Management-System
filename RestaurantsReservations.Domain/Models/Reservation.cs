namespace RestaurantsReservations.Domain.Models;

public class Reservation
{
    public int Id { get; set; }
    public DateTime ReservationDate { get; set; }
    public int PartySize { get; set; }
    public int CustomerId { get; set; }
    public int TableId { get; set; }
    public int RestaurantId { get; set; }
}