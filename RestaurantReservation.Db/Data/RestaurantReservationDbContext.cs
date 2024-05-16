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

    // public DbSet<OrderItem> OrderItems { get; set; }
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
        modelBuilder.Entity<Reservation>()
           .HasMany(r => r.Orders)
           .WithOne(o => o.Reservation)
           .HasForeignKey("ReservationId").OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Table>()
            .HasMany(t => t.Reservations)
            .WithOne(r => r.Table)
            .HasForeignKey("ReservationId").OnDelete(DeleteBehavior.Restrict);

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


    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Employee>(
    //         employee =>
    //         {
    //             employee.HasOne<Restaurant>(e => e.Restaurant)
    //                 .WithMany(r => r.Employees)
    //                 .HasForeignKey(r => r.Id)
    //                 .OnDelete(DeleteBehavior.Cascade);
    //             employee.HasMany<Order>(e => e.Orders)
    //                 .WithOne(o => o.Employee)
    //                 .HasForeignKey(o => o.Id)
    //                 .OnDelete(DeleteBehavior.Cascade);
    //         });
    //     modelBuilder.Entity<Customer>(
    //         customer =>
    //         {
    //             customer.HasMany<Reservation>(c => c.Reservations)
    //                 .WithOne(r => r.Customer)
    //                 .HasForeignKey(r => r.Id)
    //                 .OnDelete(DeleteBehavior.Cascade);
    //         });
    //     modelBuilder.Entity<MenuItem>(
    //         menuItem =>
    //         {
    //             menuItem.HasOne<Restaurant>(m => m.Restaurant)
    //                 .WithMany(r => r.MenuItems)
    //                 .HasForeignKey(m => m.Id)
    //                 .OnDelete(DeleteBehavior.Cascade);
    //         });
    //     modelBuilder.Entity<Order>(
    //         order =>
    //         {
    //             order.HasOne<Reservation>(o => o.Reservation)
    //                 .WithMany(r => r.Orders)
    //                 .HasForeignKey(o => o.Id)
    //                 .OnDelete(DeleteBehavior.Cascade);
    //             order.HasOne<Employee>(o => o.Employee)
    //                 .WithMany(e => e.Orders)
    //                 .HasForeignKey(o => o.Id)
    //                 .OnDelete(DeleteBehavior.Cascade);
    //         });
    //     modelBuilder.Entity<Order>()
    //         .HasMany(o => o.Items)
    //         .WithMany(m => m.Orders)
    //         .UsingEntity<OrderItem>(
    //             join => join
    //                 .HasOne<MenuItem>()
    //                 .WithMany()
    //                 .HasForeignKey(oi => oi.MenuItemId),
    //             join => join
    //                 .HasOne<Order>()
    //                 .WithMany()
    //                 .HasForeignKey(oi => oi.OrderId));
    //     modelBuilder.Entity<OrderItem>()
    //         .Property(ca => ca.OrderId).HasColumnName("OrdersOrderId");
    //     modelBuilder.Entity<OrderItem>()
    //         .Property(ca => ca.MenuItemId).HasColumnName("ItemsItemId");
    //     modelBuilder.Entity<Reservation>(
    //         reservation =>
    //         {
    //             reservation.HasOne<Customer>(r => r.Customer)
    //                 .WithMany(c => c.Reservations)
    //                 .HasForeignKey(r => r.Id)
    //                 .OnDelete(DeleteBehavior.Cascade);
    //             reservation.HasMany<Order>(r => r.Orders)
    //                 .WithOne(o => o.Reservation)
    //                 .HasForeignKey(o => o.Id)
    //                 .OnDelete(DeleteBehavior.Cascade);
    //             reservation.HasOne<Restaurant>(r => r.Restaurant)
    //                 .WithMany(r => r.Reservations)
    //                 .HasForeignKey(o => o.Id)
    //                 .OnDelete(DeleteBehavior.Cascade);
    //             reservation.HasOne<Table>(r => r.Table)
    //                 .WithMany(t => t.Reservations)
    //                 .HasForeignKey(r => r.Table)
    //                 .OnDelete(DeleteBehavior.Cascade);
    //         });
    //     modelBuilder.Entity<Restaurant>(
    //         restaurant =>
    //         {
    //             restaurant.HasMany<Employee>(r => r.Employees)
    //                 .WithOne(e => e.Restaurant)
    //                 .HasForeignKey(o => o.Id)
    //                 .OnDelete(DeleteBehavior.Cascade);
    //             restaurant.HasMany<Reservation>(r => r.Reservations)
    //                 .WithOne(e => e.Restaurant)
    //                 .HasForeignKey(o => o.Id)
    //                 .OnDelete(DeleteBehavior.Cascade);
    //             restaurant.HasMany<Table>(r => r.Tables)
    //                 .WithOne(e => e.Restaurant)
    //                 .HasForeignKey(o => o.Id)
    //                 .OnDelete(DeleteBehavior.Cascade);
    //             restaurant.HasMany<MenuItem>(r => r.MenuItems)
    //                 .WithOne(e => e.Restaurant)
    //                 .HasForeignKey(o => o.Id)
    //                 .OnDelete(DeleteBehavior.Cascade);
    //         });
    //     modelBuilder.Entity<Table>(
    //         table =>
    //         {
    //             table.HasOne<Restaurant>(e => e.Restaurant)
    //                 .WithMany(r => r.Tables)
    //                 .HasForeignKey(r => r.Id)
    //                 .OnDelete(DeleteBehavior.Cascade);
    //             table.HasMany<Reservation>(e => e.Reservations)
    //                 .WithOne(o => o.Table)
    //                 .HasForeignKey(o => o.Id)
    //                 .OnDelete(DeleteBehavior.Cascade);
    //         });
    // }
    
}