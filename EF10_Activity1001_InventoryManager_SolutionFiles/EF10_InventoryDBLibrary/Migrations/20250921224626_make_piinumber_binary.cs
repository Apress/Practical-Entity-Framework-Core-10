using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF10_InventoryDBLibrary.Migrations
{
    /// <inheritdoc />
    public partial class make_piinumber_binary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PIINumber",
                table: "Items",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PIINumber",
                table: "Items");
        }
    }
}
