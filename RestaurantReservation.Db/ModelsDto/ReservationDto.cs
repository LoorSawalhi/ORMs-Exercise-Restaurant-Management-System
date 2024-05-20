namespace RestaurantReservation.Db.ModelsDto;

public record ReservationDto
{
    public ReservationDto(int id, DateTime reservationDate, int partySize, string customerName, int tableId, string restaurantName)
    {
        Id = id;
        ReservationDate = reservationDate;
        PartySize = partySize;
        CustomerName = customerName;
        TableId = tableId;
        RestaurantName = restaurantName;
    }

    public int Id { get; set; }
    public DateTime ReservationDate { get; set; }
    public int PartySize { get; set; }
    public string CustomerName { get; set; }
    public int TableId { get; set; }
    public string RestaurantName { get; set; }
}