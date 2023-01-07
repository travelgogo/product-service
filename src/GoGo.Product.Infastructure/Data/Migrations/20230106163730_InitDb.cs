using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoGo.Product.Infastructure.Data.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TourRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequesterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequesterEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequesterPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeopleNumber = table.Column<int>(type: "int", nullable: false),
                    BudgetPerPerson = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LocalTarget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelRank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimateCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UtcDateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtcDateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourDay = table.Column<int>(type: "int", nullable: false),
                    AdultPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChildrenUnder2Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ChildrenFrom2To5Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ChildrenFrom5To11Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    PromotionPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Rating = table.Column<byte>(type: "tinyint", nullable: true),
                    TotalRating = table.Column<int>(type: "int", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelLocationId = table.Column<int>(type: "int", nullable: false),
                    UtcDateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtcDateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TourBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    TourHasStartDateId = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookerFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookerNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdultQuantity = table.Column<int>(type: "int", nullable: false),
                    ChildrenUnder2 = table.Column<int>(type: "int", nullable: true),
                    ChildrenFrom2To5 = table.Column<int>(type: "int", nullable: true),
                    ChildrenFrom5To11 = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UtcDateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtcDateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourBookings_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourHasStartDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemainSlots = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "TourRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OneStarAmount = table.Column<int>(type: "int", nullable: true),
                    TwoStarAmount = table.Column<int>(type: "int", nullable: true),
                    ThreeStarAmount = table.Column<int>(type: "int", nullable: true),
                    FourStarAmount = table.Column<int>(type: "int", nullable: true),
                    FiveStarAmount = table.Column<int>(type: "int", nullable: true),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    UtcDateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UtcDateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourRatings_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourBookings_TourId",
                table: "TourBookings",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TourHasStartDates_TourId",
                table: "TourHasStartDates",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TourRatings_TourId",
                table: "TourRatings",
                column: "TourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourBookings");

            migrationBuilder.DropTable(
                name: "TourHasStartDates");

            migrationBuilder.DropTable(
                name: "TourRatings");

            migrationBuilder.DropTable(
                name: "TourRequests");

            migrationBuilder.DropTable(
                name: "Tours");
        }
    }
}
