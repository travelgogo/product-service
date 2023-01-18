using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoGo.Product.Infastructure.Data.Migrations
{
    public partial class AddColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Slot",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "AdultPrice",
                table: "TourHasStartDates",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ChildrenFrom2To5Price",
                table: "TourHasStartDates",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ChildrenFrom5To11Price",
                table: "TourHasStartDates",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ChildrenUnder2Price",
                table: "TourHasStartDates",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slot",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "AdultPrice",
                table: "TourHasStartDates");

            migrationBuilder.DropColumn(
                name: "ChildrenFrom2To5Price",
                table: "TourHasStartDates");

            migrationBuilder.DropColumn(
                name: "ChildrenFrom5To11Price",
                table: "TourHasStartDates");

            migrationBuilder.DropColumn(
                name: "ChildrenUnder2Price",
                table: "TourHasStartDates");
        }
    }
}
