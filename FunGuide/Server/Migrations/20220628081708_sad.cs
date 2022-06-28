using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunGuide.Server.Migrations
{
    public partial class sad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sportsmen",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sportsmen",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sportsmen",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sportsmen",
                keyColumn: "Id",
                keyValue: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sportsmen",
                columns: new[] { "Id", "Age", "BirthDate", "CitizenshipId", "FirstName", "Height", "LastName", "SportId", "Team", "Weight" },
                values: new object[,]
                {
                    { 1, 34, new DateTime(1988, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Steph", 1.8799999999999999, "Curry", 3, "Golden State", 84.0 },
                    { 2, 37, new DateTime(1985, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Cristiano", 1.8700000000000001, "Ronaldo", 1, "Manchester United", 85.0 },
                    { 3, 33, new DateTime(1988, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Conor", 1.77, "McGregor", 2, null, 77.0 },
                    { 4, 37, new DateTime(1984, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Lebron", 2.0600000000000001, "James", 3, "LA Lakers", 113.0 }
                });
        }
    }
}
