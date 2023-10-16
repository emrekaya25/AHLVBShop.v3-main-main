using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AHLVBShop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migra25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Request",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Request");
        }
    }
}
