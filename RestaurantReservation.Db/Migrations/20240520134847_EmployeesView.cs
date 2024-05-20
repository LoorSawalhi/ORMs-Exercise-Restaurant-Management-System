using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class EmployeesView : Migration
    {  /// <inheritdoc />
            protected override void Up(MigrationBuilder migrationBuilder)
            {
                var command = @"CREATE VIEW EmployeesView
                                AS
                                SELECT
                                    e.Id, FirstName, LastName, Position,
                                    Name as RestaurantName, Address , PhoneNumber, OpeningHours
                                FROM
                                   Employees e
                                INNER JOIN Restaurants r
                                        ON e.RestaurantId = r.Id;";
                migrationBuilder.Sql(command);
            }

            /// <inheritdoc />
            protected override void Down(MigrationBuilder migrationBuilder)
            {
                var command = @"DROP VIEW EmployeesView;";
                migrationBuilder.Sql(command);
            }
    
    }
}
