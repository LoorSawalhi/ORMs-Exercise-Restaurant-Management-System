namespace RestaurantReservation.Db.Models;

public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Restaurant Restaurant { get; set; }
    public int RestaurantId { get; set; }
    public List<OrderItem> Items { get; set; }
}