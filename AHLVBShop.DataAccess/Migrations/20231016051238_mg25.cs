using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AHLVBShop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mg25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("ea7a5630-c7c0-46f0-a026-c395716077a0"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("51746015-2d9b-4519-b05b-faa96724a29f"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("51746015-2d9b-4519-b05b-faa96724a29f"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("ea7a5630-c7c0-46f0-a026-c395716077a0"));
        }
    }
}
