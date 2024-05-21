using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class RestaurantRevenueFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var command = @"CREATE FUNCTION TotalRevenueByRestaurantId(@restaurantId int)
                            RETURNS MONEY
                            AS
                            BEGIN
                                RETURN (SELECT ISNULL(SUM(O.TotalAmount), 0) as TotalRevenue
                                        FROM Reservations
                                            right join dbo.Restaurants R2 on R2.Id = Reservations.RestaurantId
                                        join dbo.Orders O on Reservations.Id = O.ReservationId
                                        WHERE R2.Id = @restaurantId);
                            END";
            migrationBuilder.Sql(command);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var command = @"drop function TotalRevenueByRestaurantId;";
            migrationBuilder.Sql(command);
        }
    }
}
