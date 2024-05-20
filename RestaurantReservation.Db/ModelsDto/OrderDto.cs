namespace RestaurantReservation.Db.ModelsDto;

public record OrderDto
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }

    public OrderDto(int id, DateTime orderDate, decimal totalAmount, int employeeId, List<OrderItemDto> items)
    {
        Id = id;
        OrderDate = orderDate;
        TotalAmount = totalAmount;
        EmployeeId = employeeId;
        Items = items;
    }

    public int EmployeeId { get; set; }
    public List<OrderItemDto> Items { get; set; }
}