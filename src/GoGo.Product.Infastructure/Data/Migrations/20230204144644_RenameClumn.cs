using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoGo.Product.Infastructure.Data.Migrations
{
    public partial class RenameClumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourHasStartDates");

            migrationBuilder.RenameColumn(
                name: "TourHasStartDateId",
                table: "TourBookings",
                newName: "TourStartDateId");

            migrationBuilder.CreateTable(
                name: "TourStartDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemainSlot = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    AdultPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChildrenUnder2Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ChildrenFrom2To5Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ChildrenFrom5To11Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UtcDateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtcDateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourStartDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourStartDates_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourStartDates_TourId",
                table: "TourStartDates",
                column: "TourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourStartDates");

            migrationBuilder.RenameColumn(
                name: "TourStartDateId",
                table: "TourBookings",
                newName: "TourHasStartDateId");

            migrationBuilder.CreateTable(
                name: "TourHasStartDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    AdultPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChildrenFrom2To5Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ChildrenFrom5To11Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ChildrenUnder2Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemainSlots = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    UtcDateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtcDateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourHasStartDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourHasStartDates_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourHasStartDates_TourId",
                table: "TourHasStartDates",
                column: "TourId");
        }
    }
}
