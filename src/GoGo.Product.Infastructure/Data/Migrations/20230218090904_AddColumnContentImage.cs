using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoGo.Product.Infastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnContentImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentImage",
                table: "Tours",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentImage",
                table: "Tours");
        }
    }
}
