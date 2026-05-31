using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AfriHaul.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carriers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LicenseNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    Rating = table.Column<double>(type: "double precision", precision: 3, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Company = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fleets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CarrierId = table.Column<Guid>(type: "uuid", nullable: false),
                    RegistrationPlate = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    VehicleType = table.Column<string>(type: "text", nullable: false),
                    MaxPayloadTons = table.Column<decimal>(type: "numeric(8,2)", precision: 8, scale: 2, nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    CurrentLocationLandmark = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fleets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fleets_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShipperId = table.Column<Guid>(type: "uuid", nullable: false),
                    CarrierId = table.Column<Guid>(type: "uuid", nullable: true),
                    OriginLandmark = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    OriginCity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    OriginCountry = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DestinationLandmark = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DestinationCity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DestinationCountry = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    WeightTons = table.Column<decimal>(type: "numeric(8,2)", precision: 8, scale: 2, nullable: false),
                    CargoDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    RequiredVehicleType = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    AgreedPriceZAR = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: true),
                    PickupDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipments_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shipments_Shippers_ShipperId",
                        column: x => x.ShipperId,
                        principalTable: "Shippers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fleets_CarrierId",
                table: "Fleets",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_CarrierId",
                table: "Shipments",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ShipperId",
                table: "Shipments",
                column: "ShipperId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fleets");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "Carriers");

            migrationBuilder.DropTable(
                name: "Shippers");
        }
    }
}
