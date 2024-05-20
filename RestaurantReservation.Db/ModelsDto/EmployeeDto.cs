namespace RestaurantReservation.Db.ModelsDto;

public record EmployeeDto
{
    public EmployeeDto(int id, string firstName, string lastName, string position)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Position = position;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
}