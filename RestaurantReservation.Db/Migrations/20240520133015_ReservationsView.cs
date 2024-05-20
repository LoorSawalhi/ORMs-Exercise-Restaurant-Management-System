using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class ReservationsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var command = @"CREATE VIEW ReservationsView
                            AS
                            SELECT
                                r.Id as ReservationId, ReservationDate, PartySize, TableId,
                                c.FirstName as CustomerFirstName, LastName as CustomerLastName, 
                                Email as CustomerEmail, c.PhoneNumber as CustomerNumber,
                                Name as RestaurantName, Address as RestaurantAddress, 
                                r2.PhoneNumber as RestaurantNumber, OpeningHours
                            FROM
                               Reservations r
                            INNER JOIN Customers c
                                    ON c.Id = r.CustomerId
                            INNER JOIN Restaurants r2
                                ON r2.Id = r.RestaurantId;";
            migrationBuilder.Sql(command);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var command = @"DROP VIEW ReservationsView;";
            migrationBuilder.Sql(command);
        }
    }
}