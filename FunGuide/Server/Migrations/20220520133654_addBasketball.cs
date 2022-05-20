using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunGuide.Server.Migrations
{
    public partial class addBasketball : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Basketball" });

            migrationBuilder.UpdateData(
                table: "Sportsmen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Age",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sportsmen",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "BirthDate" },
                values: new object[] { 0, new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sports",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Sportsmen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Age",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Sportsmen",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "BirthDate" },
                values: new object[] { 21, new DateTime(2022, 4, 28, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
