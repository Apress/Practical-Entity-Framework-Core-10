using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF10_NewFeaturesDbLibrary.Migrations
{
    /// <inheritdoc />
    public partial class createvwGetItemDetailSummaries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SqlResource("EF10_NewFeaturesDbLibrary.Migrations.Scripts.Views.vwGetItemDetailSummaries_v0.sql");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS vwGetItemDetailSummaries;");
        }
    }
}
