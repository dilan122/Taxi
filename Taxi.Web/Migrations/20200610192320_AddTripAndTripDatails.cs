using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taxi.Web.Migrations
{
    public partial class AddTripAndTripDatails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Taxis",
                table: "Taxis");

            migrationBuilder.RenameTable(
                name: "Taxis",
                newName: "TaxiEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxiEntity",
                table: "TaxiEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TripEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Source = table.Column<string>(maxLength: 100, nullable: true),
                    Target = table.Column<string>(maxLength: 100, nullable: true),
                    Qualification = table.Column<float>(nullable: false),
                    SourceLatitude = table.Column<double>(nullable: false),
                    SourceLongitude = table.Column<double>(nullable: false),
                    TargetLatitude = table.Column<double>(nullable: false),
                    TargetLongitude = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    TaxiId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripEntity_TaxiEntity_TaxiId",
                        column: x => x.TaxiId,
                        principalTable: "TaxiEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripDetailEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    TripId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDetailEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripDetailEntity_TripEntity_TripId",
                        column: x => x.TripId,
                        principalTable: "TripEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripDetailEntity_TripId",
                table: "TripDetailEntity",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripEntity_TaxiId",
                table: "TripEntity",
                column: "TaxiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripDetailEntity");

            migrationBuilder.DropTable(
                name: "TripEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxiEntity",
                table: "TaxiEntity");

            migrationBuilder.RenameTable(
                name: "TaxiEntity",
                newName: "Taxis");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Taxis",
                table: "Taxis",
                column: "Id");
        }
    }
}
