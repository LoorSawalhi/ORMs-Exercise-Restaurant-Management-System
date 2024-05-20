﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantReservation.Db.Data;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    [DbContext(typeof(RestaurantReservationDbContext))]
    [Migration("20240520133015_ReservationsView")]
    partial class ReservationsView
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantReservation.Db.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            PhoneNumber = "123-456-7890"
                        },
                        new
                        {
                            Id = 2,
                            Email = "mary.smith@example.com",
                            FirstName = "Mary",
                            LastName = "Smith",
                            PhoneNumber = "321-654-9870"
                        },
                        new
                        {
                            Id = 3,
                            Email = "david.brown@example.com",
                            FirstName = "David",
                            LastName = "Brown",
                            PhoneNumber = "456-789-1230"
                        },
                        new
                        {
                            Id = 4,
                            Email = "linda.white@example.com",
                            FirstName = "Linda",
                            LastName = "White",
                            PhoneNumber = "654-987-3210"
                        },
                        new
                        {
                            Id = 5,
                            Email = "james.davis@example.com",
                            FirstName = "James",
                            LastName = "Davis",
                            PhoneNumber = "789-123-4560"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Jane",
                            LastName = "Smith",
                            Position = "Waitress",
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Robert",
                            LastName = "Jones",
                            Position = "Chef",
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Michael",
                            LastName = "Lee",
                            Position = "Manager",
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Sarah",
                            LastName = "Wilson",
                            Position = "Host",
                            RestaurantId = 4
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "William",
                            LastName = "Taylor",
                            Position = "Bartender",
                            RestaurantId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A juicy 12 oz Ribeye steak.",
                            Name = "Ribeye Steak",
                            Price = 25.99m,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Traditional Italian pizza with fresh mozzarella and basil.",
                            Name = "Classic Margherita",
                            Price = 15.75m,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "A delicious and healthy plant-based burger.",
                            Name = "Vegan Burger",
                            Price = 13.50m,
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 4,
                            Description = "An assortment of fresh sushi.",
                            Name = "Sushi Platter",
                            Price = 22.00m,
                            RestaurantId = 4
                        },
                        new
                        {
                            Id = 5,
                            Description = "Two beef patties with cheese, lettuce, tomato, and sauce.",
                            Name = "Double Cheeseburger",
                            Price = 11.00m,
                            RestaurantId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 1,
                            OrderDate = new DateTime(2024, 5, 20, 16, 30, 14, 700, DateTimeKind.Local).AddTicks(7263),
                            ReservationId = 1,
                            TotalAmount = 51.98m
                        },
                        new
                        {
                            Id = 2,
                            EmployeeId = 2,
                            OrderDate = new DateTime(2024, 5, 20, 16, 30, 14, 700, DateTimeKind.Local).AddTicks(7270),
                            ReservationId = 2,
                            TotalAmount = 31.50m
                        },
                        new
                        {
                            Id = 3,
                            EmployeeId = 3,
                            OrderDate = new DateTime(2024, 5, 20, 16, 30, 14, 700, DateTimeKind.Local).AddTicks(7275),
                            ReservationId = 3,
                            TotalAmount = 27.00m
                        },
                        new
                        {
                            Id = 4,
                            EmployeeId = 4,
                            OrderDate = new DateTime(2024, 5, 20, 16, 30, 14, 700, DateTimeKind.Local).AddTicks(7279),
                            ReservationId = 4,
                            TotalAmount = 44.00m
                        },
                        new
                        {
                            Id = 5,
                            EmployeeId = 5,
                            OrderDate = new DateTime(2024, 5, 20, 16, 30, 14, 700, DateTimeKind.Local).AddTicks(7283),
                            ReservationId = 5,
                            TotalAmount = 22.00m
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MenuItemId = 1,
                            OrderId = 1,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 2,
                            MenuItemId = 4,
                            OrderId = 5,
                            Quantity = 4
                        },
                        new
                        {
                            Id = 3,
                            MenuItemId = 2,
                            OrderId = 4,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 4,
                            MenuItemId = 5,
                            OrderId = 3,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 5,
                            MenuItemId = 3,
                            OrderId = 2,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("TableId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            PartySize = 4,
                            ReservationDate = new DateTime(2024, 5, 21, 16, 30, 14, 700, DateTimeKind.Local).AddTicks(7149),
                            RestaurantId = 1,
                            TableId = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            PartySize = 2,
                            ReservationDate = new DateTime(2024, 5, 22, 16, 30, 14, 700, DateTimeKind.Local).AddTicks(7209),
                            RestaurantId = 2,
                            TableId = 2
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            PartySize = 6,
                            ReservationDate = new DateTime(2024, 5, 23, 16, 30, 14, 700, DateTimeKind.Local).AddTicks(7215),
                            RestaurantId = 3,
                            TableId = 3
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 4,
                            PartySize = 8,
                            ReservationDate = new DateTime(2024, 5, 24, 16, 30, 14, 700, DateTimeKind.Local).AddTicks(7220),
                            RestaurantId = 4,
                            TableId = 4
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = 5,
                            PartySize = 4,
                            ReservationDate = new DateTime(2024, 5, 25, 16, 30, 14, 700, DateTimeKind.Local).AddTicks(7225),
                            RestaurantId = 5,
                            TableId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.ReservationsView", b =>
                {
                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("OpeningHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RestaurantAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.ToTable((string)null);

                    b.ToView("ReservationsView", (string)null);
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "1234 Culinary Blvd.",
                            Name = "The Fancy Steakhouse",
                            OpeningHours = "9:00 AM - 11:00 PM",
                            PhoneNumber = "987-654-3210"
                        },
                        new
                        {
                            Id = 2,
                            Address = "5678 Dough St.",
                            Name = "Gourmet Pizza",
                            OpeningHours = "10:00 AM - 12:00 AM",
                            PhoneNumber = "123-987-6543"
                        },
                        new
                        {
                            Id = 3,
                            Address = "1357 Green Way",
                            Name = "Vegan Delights",
                            OpeningHours = "8:00 AM - 8:00 PM",
                            PhoneNumber = "321-654-9870"
                        },
                        new
                        {
                            Id = 4,
                            Address = "2468 Fish Ln.",
                            Name = "Sushi Corner",
                            OpeningHours = "11:00 AM - 10:00 PM",
                            PhoneNumber = "654-321-9876"
                        },
                        new
                        {
                            Id = 5,
                            Address = "1928 Grill Dr.",
                            Name = "Burger Joint",
                            OpeningHours = "11:00 AM - 11:00 PM",
                            PhoneNumber = "789-321-6543"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 4,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 2,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 6,
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 4,
                            Capacity = 8,
                            RestaurantId = 4
                        },
                        new
                        {
                            Id = 5,
                            Capacity = 4,
                            RestaurantId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Employee", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Restaurant", "Restaurant")
                        .WithMany("Employees")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.MenuItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Restaurant", "Restaurant")
                        .WithMany("MenuItems")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Order", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Models.Reservation", "Reservation")
                        .WithMany("Orders")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.OrderItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.MenuItem", "MenuItem")
                        .WithMany("Items")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Reservation", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Models.Restaurant", "Restaurant")
                        .WithMany("Reservations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Models.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Restaurant");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Table", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Models.Restaurant", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.MenuItem", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Reservation", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Restaurant", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("MenuItems");

                    b.Navigation("Reservations");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Models.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
