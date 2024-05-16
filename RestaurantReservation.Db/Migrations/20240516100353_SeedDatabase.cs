using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John", "Doe", "123-456-7890" },
                    { 2, "mary.smith@example.com", "Mary", "Smith", "321-654-9870" },
                    { 3, "david.brown@example.com", "David", "Brown", "456-789-1230" },
                    { 4, "linda.white@example.com", "Linda", "White", "654-987-3210" },
                    { 5, "james.davis@example.com", "James", "Davis", "789-123-4560" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "1234 Culinary Blvd.", "The Fancy Steakhouse", "9:00 AM - 11:00 PM", "987-654-3210" },
                    { 2, "5678 Dough St.", "Gourmet Pizza", "10:00 AM - 12:00 AM", "123-987-6543" },
                    { 3, "1357 Green Way", "Vegan Delights", "8:00 AM - 8:00 PM", "321-654-9870" },
                    { 4, "2468 Fish Ln.", "Sushi Corner", "11:00 AM - 10:00 PM", "654-321-9876" },
                    { 5, "1928 Grill Dr.", "Burger Joint", "11:00 AM - 11:00 PM", "789-321-6543" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "Position", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Jane", "Smith", "Waitress", 1 },
                    { 2, "Robert", "Jones", "Chef", 2 },
                    { 3, "Michael", "Lee", "Manager", 3 },
                    { 4, "Sarah", "Wilson", "Host", 4 },
                    { 5, "William", "Taylor", "Bartender", 5 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "A juicy 12 oz Ribeye steak.", "Ribeye Steak", 25.99m, 1 },
                    { 2, "Traditional Italian pizza with fresh mozzarella and basil.", "Classic Margherita", 15.75m, 2 },
                    { 3, "A delicious and healthy plant-based burger.", "Vegan Burger", 13.50m, 3 },
                    { 4, "An assortment of fresh sushi.", "Sushi Platter", 22.00m, 4 },
                    { 5, "Two beef patties with cheese, lettuce, tomato, and sauce.", "Double Cheeseburger", 11.00m, 5 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Capacity", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 2, 2 },
                    { 3, 6, 3 },
                    { 4, 8, 4 },
                    { 5, 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "PartySize", "ReservationDate", "RestaurantId", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 4, new DateTime(2024, 5, 17, 13, 3, 52, 571, DateTimeKind.Local).AddTicks(5488), 1, 1 },
                    { 2, 2, 2, new DateTime(2024, 5, 18, 13, 3, 52, 571, DateTimeKind.Local).AddTicks(5540), 2, 2 },
                    { 3, 3, 6, new DateTime(2024, 5, 19, 13, 3, 52, 571, DateTimeKind.Local).AddTicks(5545), 3, 3 },
                    { 4, 4, 8, new DateTime(2024, 5, 20, 13, 3, 52, 571, DateTimeKind.Local).AddTicks(5550), 4, 4 },
                    { 5, 5, 4, new DateTime(2024, 5, 21, 13, 3, 52, 571, DateTimeKind.Local).AddTicks(5554), 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "EmployeeId", "OrderDate", "ReservationId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 16, 13, 3, 52, 571, DateTimeKind.Local).AddTicks(5585), 1, 51.98m },
                    { 2, 2, new DateTime(2024, 5, 16, 13, 3, 52, 571, DateTimeKind.Local).AddTicks(5592), 2, 31.50m },
                    { 3, 3, new DateTime(2024, 5, 16, 13, 3, 52, 571, DateTimeKind.Local).AddTicks(5596), 3, 27.00m },
                    { 4, 4, new DateTime(2024, 5, 16, 13, 3, 52, 571, DateTimeKind.Local).AddTicks(5600), 4, 44.00m },
                    { 5, 5, new DateTime(2024, 5, 16, 13, 3, 52, 571, DateTimeKind.Local).AddTicks(5603), 5, 22.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
