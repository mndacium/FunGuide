using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunGuide.Server.Migrations
{
    public partial class SportsmanMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sportsmen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Сitizenship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SportId = table.Column<int>(type: "int", nullable: false),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sportsmen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sportsmen_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Football" });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "MMA" });

            migrationBuilder.InsertData(
                table: "Sportsmen",
                columns: new[] { "Id", "Age", "BirthDate", "FirstName", "Height", "LastName", "SportId", "Team", "Weight", "Сitizenship" },
                values: new object[] { 1, 22, null, "Vlad", 1.8200000000000001, "Tanasiichuk", 1, null, 75.799999999999997, "Ukrainian" });

            migrationBuilder.InsertData(
                table: "Sportsmen",
                columns: new[] { "Id", "Age", "BirthDate", "FirstName", "Height", "LastName", "SportId", "Team", "Weight", "Сitizenship" },
                values: new object[] { 2, 21, new DateTime(2022, 4, 26, 0, 0, 0, 0, DateTimeKind.Local), "Andrey", 1.8, "Huila", 2, null, 75.299999999999997, "Ukrainian" });

            migrationBuilder.CreateIndex(
                name: "IX_Sportsmen_SportId",
                table: "Sportsmen",
                column: "SportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sportsmen");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
