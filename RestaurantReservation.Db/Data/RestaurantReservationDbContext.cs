using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Data;

public class RestaurantReservationDbContext : DbContext
{
    public RestaurantReservationDbContext(DbContextOptions<RestaurantReservationDbContext> options) : base(options)
    {
    }

    public DbSet<ReservationsView> ReservationsView { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeesView> EmployeesView { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Table> Tables { get; set; }

    [DbFunction("TotalRevenueByRestaurantId", "dbo")]
    public decimal TotalRevenueByRestaurantId(int id)
    {
        throw new InvalidOperationException("This method is for use with Entity Framework Core only and has no in-memory implementation.");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedData(modelBuilder);

        modelBuilder.HasDbFunction(typeof(RestaurantReservationDbContext).GetMethod(nameof(TotalRevenueByRestaurantId)));

        modelBuilder.Entity<ReservationsView>()
            .HasNoKey()
            .ToView(nameof(ReservationsView));

        modelBuilder.Entity<EmployeesView>()
            .HasNoKey()
            .ToView(nameof(EmployeesView));

        modelBuilder.Entity<Table>()
            .HasMany(t => t.Reservations)
            .WithOne(r => r.Table)
            .HasForeignKey("TableId").OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Employees)
            .WithOne(e => e.Restaurant)
            .HasForeignKey("RestaurantId").OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.MenuItems)
            .WithOne(m => m.Restaurant)
            .HasForeignKey("RestaurantId").OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Reservations)
            .WithOne(m => m.Restaurant)
            .HasForeignKey("RestaurantId").OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Orders)
            .WithOne(o => o.Employee)
            .HasForeignKey("EmployeeId").OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Reservations)
            .WithOne(r => r.Customer)
            .HasForeignKey("CustomerId").OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Restaurant>()
            .HasMany(c => c.Tables)
            .WithOne(t => t.Restaurant)
            .HasForeignKey("RestaurantId").OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MenuItem>()
            .HasMany(m => m.Items)
            .WithOne(i => i.MenuItem)
            .HasForeignKey("MenuItemId").OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.Items)
            .WithOne(oi => oi.Order)
            .HasForeignKey("OrderId").OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MenuItem>()
            .Property(m => m.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasPrecision(18, 2);
    }

   private static void SeedData(ModelBuilder modelBuilder)
    {
               var restaurants = new List<Restaurant>
        {
            new()
            {
                Id = 1, Name = "The Fancy Steakhouse", Address = "1234 Culinary Blvd.", PhoneNumber = "987-654-3210",
                OpeningHours = "9:00 AM - 11:00 PM"
            },
            new()
            {
                Id = 2, Name = "Gourmet Pizza", Address = "5678 Dough St.", PhoneNumber = "123-987-6543",
                OpeningHours = "10:00 AM - 12:00 AM"
            },
            new()
            {
                Id = 3, Name = "Vegan Delights", Address = "1357 Green Way", PhoneNumber = "321-654-9870",
                OpeningHours = "8:00 AM - 8:00 PM"
            },
            new()
            {
                Id = 4, Name = "Sushi Corner", Address = "2468 Fish Ln.", PhoneNumber = "654-321-9876",
                OpeningHours = "11:00 AM - 10:00 PM"
            },
            new()
            {
                Id = 5, Name = "Burger Joint", Address = "1928 Grill Dr.", PhoneNumber = "789-321-6543",
                OpeningHours = "11:00 AM - 11:00 PM"
            }
        };

        var customers = new List<Customer>
        {
            new()
            {
                Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com",
                PhoneNumber = "123-456-7890"
            },
            new()
            {
                Id = 2, FirstName = "Mary", LastName = "Smith", Email = "mary.smith@example.com",
                PhoneNumber = "321-654-9870"
            },
            new()
            {
                Id = 3, FirstName = "David", LastName = "Brown", Email = "david.brown@example.com",
                PhoneNumber = "456-789-1230"
            },
            new()
            {
                Id = 4, FirstName = "Linda", LastName = "White", Email = "linda.white@example.com",
                PhoneNumber = "654-987-3210"
            },
            new()
            {
                Id = 5, FirstName = "James", LastName = "Davis", Email = "james.davis@example.com",
                PhoneNumber = "789-123-4560"
            }
        };

        var tables = new List<Table>
        {
            new() { Id = 1, Capacity = 4, RestaurantId = restaurants[0].Id },
            new() { Id = 2, Capacity = 2, RestaurantId = restaurants[1].Id },
            new() { Id = 3, Capacity = 6, RestaurantId = restaurants[2].Id },
            new() { Id = 4, Capacity = 8, RestaurantId = restaurants[3].Id },
            new() { Id = 5, Capacity = 4, RestaurantId = restaurants[4].Id }
        };

        var reservations = new List<Reservation>
        {
            new()
            {
                Id = 1, ReservationDate = DateTime.Now.AddDays(1), PartySize = 4, CustomerId = customers[0].Id,
                RestaurantId = restaurants[0].Id, TableId = tables[0].Id
            },
            new()
            {
                Id = 2, ReservationDate = DateTime.Now.AddDays(2), PartySize = 2, CustomerId = customers[1].Id,
                RestaurantId = restaurants[1].Id, TableId = tables[1].Id
            },
            new()
            {
                Id = 3, ReservationDate = DateTime.Now.AddDays(3), PartySize = 6, CustomerId = customers[2].Id,
                RestaurantId = restaurants[2].Id, TableId = tables[2].Id
            },
            new()
            {
                Id = 4, ReservationDate = DateTime.Now.AddDays(4), PartySize = 8, CustomerId = customers[3].Id,
                RestaurantId = restaurants[3].Id, TableId = tables[3].Id
            },
            new()
            {
                Id = 5, ReservationDate = DateTime.Now.AddDays(5), PartySize = 4, CustomerId = customers[4].Id,
                RestaurantId = restaurants[4].Id, TableId = tables[4].Id
            }
        };

        var employees = new List<Employee>
        {
            new() { Id = 1, FirstName = "Jane", LastName = "Smith", Position = "Waitress", RestaurantId = restaurants[0].Id },
            new() { Id = 2, FirstName = "Robert", LastName = "Jones", Position = "Chef", RestaurantId = restaurants[1].Id },
            new() { Id = 3, FirstName = "Michael", LastName = "Lee", Position = "Manager", RestaurantId = restaurants[2].Id },
            new() { Id = 4, FirstName = "Sarah", LastName = "Wilson", Position = "Host", RestaurantId = restaurants[3].Id },
            new() { Id = 5, FirstName = "William", LastName = "Taylor", Position = "Bartender", RestaurantId = restaurants[4].Id }
        };

        var menuItems = new List<MenuItem>
        {
            new()
            {
                Id = 1, Name = "Ribeye Steak", Description = "A juicy 12 oz Ribeye steak.", Price = 25.99M,
                RestaurantId = restaurants[0].Id
            },
            new()
            {
                Id = 2, Name = "Classic Margherita",
                Description = "Traditional Italian pizza with fresh mozzarella and basil.", Price = 15.75M,
                RestaurantId = restaurants[1].Id
            },
            new()
            {
                Id = 3, Name = "Vegan Burger", Description = "A delicious and healthy plant-based burger.",
                Price = 13.50M, RestaurantId = restaurants[2].Id
            },
            new()
            {
                Id = 4, Name = "Sushi Platter", Description = "An assortment of fresh sushi.", Price = 22.00M,
                RestaurantId = restaurants[3].Id
            },
            new()
            {
                Id = 5, Name = "Double Cheeseburger",
                Description = "Two beef patties with cheese, lettuce, tomato, and sauce.", Price = 11.00M,
                RestaurantId = restaurants[4].Id
            }
        };

        var orders = new List<Order>
        {
            new()
            {
                Id = 1, OrderDate = DateTime.Now, TotalAmount = 51.98M, ReservationId = reservations[0].Id,
                EmployeeId = employees[0].Id
            },
            new()
            {
                Id = 2, OrderDate = DateTime.Now, TotalAmount = 31.50M, ReservationId = reservations[1].Id,
                EmployeeId = employees[1].Id
            },
            new()
            {
                Id = 3, OrderDate = DateTime.Now, TotalAmount = 27.00M, ReservationId = reservations[2].Id,
                EmployeeId = employees[2].Id
            },
            new()
            {
                Id = 4, OrderDate = DateTime.Now, TotalAmount = 44.00M, ReservationId = reservations[3].Id,
                EmployeeId = employees[3].Id
            },
            new()
            {
                Id = 5, OrderDate = DateTime.Now, TotalAmount = 22.00M, ReservationId = reservations[4].Id,
                EmployeeId = employees[4].Id
            }
        };

        var orderItems = new List<OrderItem>
        {
            new()
            {
                Id = 1, Quantity = 3, OrderId = 1, MenuItemId = 1
            },
            new()
            {
                Id = 2, Quantity = 4, OrderId = 5, MenuItemId = 4
            },
            new()
            {
                Id = 3, Quantity = 5, OrderId = 4, MenuItemId = 2
            },
            new()
            {
                Id = 4, Quantity = 5, OrderId = 3, MenuItemId = 5
            },
            new()
            {
                Id = 5, Quantity = 2, OrderId = 2, MenuItemId = 3
            }
        };

        modelBuilder.Entity<Restaurant>().HasData(restaurants);
        modelBuilder.Entity<Customer>().HasData(customers);
        modelBuilder.Entity<Reservation>().HasData(reservations);
        modelBuilder.Entity<Table>().HasData(tables);
        modelBuilder.Entity<Employee>().HasData(employees);
        modelBuilder.Entity<MenuItem>().HasData(menuItems);
        modelBuilder.Entity<Order>().HasData(orders);
        modelBuilder.Entity<OrderItem>().HasData(orderItems);
    }
}