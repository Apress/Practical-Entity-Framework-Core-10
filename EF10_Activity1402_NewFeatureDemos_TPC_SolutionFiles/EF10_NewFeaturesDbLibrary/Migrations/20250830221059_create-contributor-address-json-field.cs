using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF10_NewFeaturesDbLibrary.Migrations
{
    /// <inheritdoc />
    public partial class createcontributoraddressjsonfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //backup tables
            migrationBuilder.SqlResource("EF10_NewFeaturesDbLibrary.Migrations.Scripts.Operations.BackupContributorsAndItemContributors_v0.sql");
            //delete the data
            migrationBuilder.Sql("DELETE FROM ItemContributors;");
            migrationBuilder.Sql("DELETE FROM Contributors;");

            //add the new column
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Contributors",
                type: "nvarchar(max)",
                nullable: true);

            //restore the data
            migrationBuilder.SqlResource("EF10_NewFeaturesDbLibrary.Migrations.Scripts.Operations.RestoreContributorsAndItemContributors_v0.sql");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //DO NOT ROLL THIS BACK. IT WILL BREAK THINGS.
        }
    }
}
