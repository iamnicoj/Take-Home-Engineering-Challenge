using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripsAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxiZones",
                columns: table => new
                {
                    TaxiZoneId = table.Column<int>(type: "int", nullable: false),
                    Borough = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxiZones", x => x.TaxiZoneId);
                });

            migrationBuilder.CreateTable(
                name: "TripsInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickupDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false, computedColumnSql: "DATEPART(YYYY,[PickupDateTime])", stored: true),
                    Month = table.Column<int>(type: "int", nullable: false, computedColumnSql: "DATEPART(m,[PickupDateTime])", stored: true),
                    Hour = table.Column<int>(type: "int", nullable: false, computedColumnSql: "DATEPART(HOUR,[PickupDateTime])", stored: true),
                    WeekDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DropOffDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassangerCount = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    Fare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FareRange = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Distance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DistanceRange = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false, computedColumnSql: "DATEDIFF(minute, [PickupDateTime], [DropOffDateTime])", stored: true),
                    DurationRange = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Operator = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    DropOffZoneId = table.Column<int>(type: "int", nullable: false),
                    DropOffBorough = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DropOffZone = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PickUpZoneId = table.Column<int>(type: "int", nullable: false),
                    PickUpBorough = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PickUpZone = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripsInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripsInfo_DistanceRange",
                table: "TripsInfo",
                column: "DistanceRange");

            migrationBuilder.CreateIndex(
                name: "IX_TripsInfo_DropOffBorough",
                table: "TripsInfo",
                column: "DropOffBorough");

            migrationBuilder.CreateIndex(
                name: "IX_TripsInfo_DropOffDateTime",
                table: "TripsInfo",
                column: "DropOffDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TripsInfo_DropOffZone",
                table: "TripsInfo",
                column: "DropOffZone");

            migrationBuilder.CreateIndex(
                name: "IX_TripsInfo_DurationRange",
                table: "TripsInfo",
                column: "DurationRange");

            migrationBuilder.CreateIndex(
                name: "IX_TripsInfo_FareRange",
                table: "TripsInfo",
                column: "FareRange");

            migrationBuilder.CreateIndex(
                name: "IX_TripsInfo_PickUpBorough",
                table: "TripsInfo",
                column: "PickUpBorough");

            migrationBuilder.CreateIndex(
                name: "IX_TripsInfo_PickupDateTime",
                table: "TripsInfo",
                column: "PickupDateTime");

            migrationBuilder.CreateIndex(
                name: "IX_TripsInfo_PickUpZone",
                table: "TripsInfo",
                column: "PickUpZone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxiZones");

            migrationBuilder.DropTable(
                name: "TripsInfo");
        }
    }
}
