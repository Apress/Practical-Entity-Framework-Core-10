using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF10_InventoryDBLibrary.Migrations
{
    /// <inheritdoc />
    public partial class createfnTopValuedItemsfunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SqlResource("EF10_InventoryDBLibrary.Migrations.Scripts.Functions.TopValuedItems.TopValuedItems_v0.sql");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS fnTopValuedItems");
        }
    }
}
