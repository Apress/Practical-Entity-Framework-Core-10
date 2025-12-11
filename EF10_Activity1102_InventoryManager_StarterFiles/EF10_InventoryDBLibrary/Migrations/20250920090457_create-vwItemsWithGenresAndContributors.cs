using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF10_InventoryDBLibrary.Migrations
{
    /// <inheritdoc />
    public partial class createvwItemsWithGenresAndContributors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SqlResource("EF10_InventoryDBLibrary.Migrations.Scripts.Views.ItemsWithGenresAndContributors.vwItemsWithGenresAndContributors_v0.sql");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS dbo.vwItemsWithGenresAndContributors");
        }
    }
}
