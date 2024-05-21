using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class CustomersPartSizeProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var command = @"CREATE PROCEDURE FindCustomersByMinimumPartySize(@size int)
                            AS BEGIN
                                SELECT Customers.id, firstname, lastname, email, phonenumber, PartySize
                                FROM Customers
                                JOIN dbo.Reservations R ON Customers.Id = R.CustomerId
                                WHERE PartySize >= @size
                            END;";
            migrationBuilder.Sql(command);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var command = @"DROP PROCEDURE FindCustomersByMinimumPartySize;";
            migrationBuilder.Sql(command);
        }
    }
}
