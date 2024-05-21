namespace RestaurantReservation.Db.ModelsDto;

public record OrderDto
{
    public OrderDto(int id, DateTime orderDate, decimal totalAmount, int employeeId, List<OrderItemDto> items)
     {
         Id = id;
         OrderDate = orderDate;
         TotalAmount = totalAmount;
         EmployeeId = employeeId;
         Items = items;
     }

    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }

    public int EmployeeId { get; set; }
    public List<OrderItemDto> Items { get; set; }

    public override string ToString()
    {
        return $"Id = {Id}, Order Date = {OrderDate}, Total Amount = {TotalAmount}, Employee Id = {EmployeeId}";
    }
}