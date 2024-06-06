namespace RestaurantsReservations.Domain.Models;

public record OrderItemDto
{
    public int Quantity { get; set; }
    public string MenuItemName { get; set; }
    
    public string MenuItemDescription { get; set; }
    public OrderItemDto(int quantity, string menuItemName, string menuItemDescription)
   {
       Quantity = quantity;
       MenuItemName = menuItemName;
       MenuItemDescription = menuItemDescription;
   }

}