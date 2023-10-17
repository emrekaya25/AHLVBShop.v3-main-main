using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AHLVBShop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class m25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Offer");
        }
    }
}
