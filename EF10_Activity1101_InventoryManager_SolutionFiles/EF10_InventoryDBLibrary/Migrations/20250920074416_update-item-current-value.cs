using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF10_InventoryDBLibrary.Migrations
{
    /// <inheritdoc />
    public partial class updateitemcurrentvalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SqlResource("EF10_InventoryDBLibrary.Migrations.Scripts.Operations.UpdateItemCurrentValue_v0.sql");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Update Items SET CurrentValue = null");
            migrationBuilder.Sql(@"UPDATE Items SET Quantity = 1");
        }
    }
}
