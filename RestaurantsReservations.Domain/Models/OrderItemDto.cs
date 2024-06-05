namespace RestaurantReservation.Db.ModelsDto;

public record OrderItemDto
{
    public int Quantity { get; set; }
    public string MenuItemName { get; set; }

    public OrderItemDto(int quantity, string menuItemName, string menuItemDescription)
    {
        Quantity = quantity;
        MenuItemName = menuItemName;
        MenuItemDescription = menuItemDescription;
    }

    public string MenuItemDescription { get; set; }
}