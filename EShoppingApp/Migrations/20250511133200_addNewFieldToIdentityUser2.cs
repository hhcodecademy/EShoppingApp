using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShoppingApp.Migrations
{
    /// <inheritdoc />
    public partial class addNewFieldToIdentityUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastLoginIpAdr",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLoginIpAdr",
                table: "AspNetUsers");
        }
    }
}
