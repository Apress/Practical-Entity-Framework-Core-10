using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF10_NewFeaturesDbLibrary.Migrations
{
    /// <inheritdoc />
    public partial class seedmoviesandbooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "CategoryId", "Description", "ISBN", "IsActive", "IsDeleted", "ItemName", "PlotSummary", "TenantId" },
                values: new object[,]
                {
                    { 51, 2, "A test book 1", "978-0547928210", true, false, "book 1", "it thickens 1", 1 },
                    { 52, 2, "A test book 2", "978-0441013593", true, false, "book 2", "it thickens 2", 1 },
                    { 53, 2, "A test book 3", "978-0590353427", true, false, "book 3", "it thickens 3", 1 },
                    { 54, 2, "A test book 4", "978-0307743657", true, false, "book 4", "it thickens 4", 1 },
                    { 55, 2, "A test book 5", "978-0062693662", true, false, "book 5", "it thickens 5", 1 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "Description", "IsActive", "IsDeleted", "ItemName", "MPAARating", "PlotSummary", "TenantId" },
                values: new object[,]
                {
                    { 56, 1, "A test movie 1", true, false, "movie 1", "R", "Action Packed Missions 1", 1 },
                    { 57, 1, "A test movie 2", true, false, "movie 2", "G", "Action Packed Missions 2", 1 },
                    { 58, 1, "A test movie 3", true, false, "movie 3", "PG", "Action Packed Missions 3", 1 },
                    { 59, 1, "A test movie 4", true, false, "movie 4", "PG-13", "Action Packed Missions 4", 1 },
                    { 60, 1, "A test movie 5", true, false, "movie 5", "PG", "Action Packed Missions 5", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
