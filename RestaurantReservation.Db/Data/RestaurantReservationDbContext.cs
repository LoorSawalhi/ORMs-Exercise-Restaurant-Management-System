using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Data;

public class RestaurantReservationDbContext : DbContext
{
    public RestaurantReservationDbContext(DbContextOptions<RestaurantReservationDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Table> Tables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasMany(o => o.Items)
            .WithMany(m => m.Orders)
            .UsingEntity<OrderItem>(
                join => join
                    .HasOne<MenuItem>()
                    .WithMany()
                    .HasForeignKey(oi => oi.MenuItemId),
                join => join
                    .HasOne<Order>()
                    .WithMany()
                    .HasForeignKey(oi => oi.OrderId));
        modelBuilder.Entity<OrderItem>()
            .Property(ca => ca.OrderId).HasColumnName("OrdersOrderId");
        modelBuilder.Entity<OrderItem>()
            .Property(ca => ca.MenuItemId).HasColumnName("ItemsItemId");

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
            .Property(m => m.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasPrecision(18, 2);
    }
}