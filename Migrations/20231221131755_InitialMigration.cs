using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaceTrackingAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    IdCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", maxLength: 100, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.IdCar);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    IdPart = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.IdPart);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    IdRace = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.IdRace);
                });

            migrationBuilder.CreateTable(
                name: "PartInCars",
                columns: table => new
                {
                    IdPart = table.Column<int>(type: "int", nullable: false),
                    IdCar = table.Column<int>(type: "int", nullable: false),
                    MountedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastServiceDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartInCars", x => new { x.IdPart, x.IdCar });
                    table.ForeignKey(
                        name: "FK_PartInCars_Cars_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Cars",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartInCars_Parts_IdPart",
                        column: x => x.IdPart,
                        principalTable: "Parts",
                        principalColumn: "IdPart",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarsInRaces",
                columns: table => new
                {
                    IdCar = table.Column<int>(type: "int", nullable: false),
                    IdRace = table.Column<int>(type: "int", nullable: false),
                    IsConfirmedByDriver = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsInRaces", x => new { x.IdCar, x.IdRace });
                    table.ForeignKey(
                        name: "FK_CarsInRaces_Cars_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Cars",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarsInRaces_Races_IdRace",
                        column: x => x.IdRace,
                        principalTable: "Races",
                        principalColumn: "IdRace",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarsInRaces_IdRace",
                table: "CarsInRaces",
                column: "IdRace");

            migrationBuilder.CreateIndex(
                name: "IX_PartInCars_IdCar",
                table: "PartInCars",
                column: "IdCar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarsInRaces");

            migrationBuilder.DropTable(
                name: "PartInCars");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Parts");
        }
    }
}
