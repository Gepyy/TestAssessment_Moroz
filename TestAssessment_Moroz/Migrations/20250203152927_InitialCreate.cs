using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAssessment_Moroz.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pickup_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dropoff_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Passenger_count = table.Column<int>(type: "int", nullable: false),
                    Trip_distance = table.Column<double>(type: "float", nullable: false),
                    Store_and_fwd_flag = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    PULocationID = table.Column<int>(type: "int", nullable: false),
                    DOLocationID = table.Column<int>(type: "int", nullable: false),
                    Fare_amount = table.Column<double>(type: "float", nullable: false),
                    Tip_amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_PULocationID",
                table: "Models",
                column: "PULocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TravelTime",
                table: "Models",
                columns: new[] { "Pickup_datetime", "Dropoff_datetime" });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TripDistance",
                table: "Models",
                column: "Trip_distance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}
