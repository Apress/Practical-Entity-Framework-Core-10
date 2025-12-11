using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF10_NewFeaturesDbLibrary.Migrations
{
    /// <inheritdoc />
    public partial class changekeyforictable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemContributors",
                table: "ItemContributors");

            migrationBuilder.Sql(@"DELETE FROM ItemContributors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItemContributors");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ItemContributors",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemContributors",
                table: "ItemContributors",
                column: "Id");

            migrationBuilder.InsertData(
                table: "ItemContributors",
                columns: new[] { "Id", "ContributorId", "ContributorType", "IsActive", "ItemId" },
                values: new object[,]
                {
                    { 1, 1, 6, true, 1 },
                    { 2, 2, 6, true, 1 },
                    { 3, 3, 4, true, 1 },
                    { 4, 4, 7, true, 1 },
                    { 5, 5, 0, true, 2 },
                    { 6, 6, 9, true, 3 },
                    { 7, 7, 10, true, 4 },
                    { 8, 8, 6, true, 5 },
                    { 9, 9, 6, true, 5 },
                    { 10, 10, 4, true, 5 },
                    { 11, 11, 7, true, 5 },
                    { 12, 12, 7, true, 5 },
                    { 13, 14, 4, true, 6 },
                    { 14, 15, 6, true, 6 },
                    { 15, 16, 6, true, 6 },
                    { 16, 11, 7, true, 6 },
                    { 17, 19, 4, true, 7 },
                    { 18, 18, 6, true, 7 },
                    { 19, 22, 4, true, 8 },
                    { 20, 23, 6, true, 8 },
                    { 21, 10, 4, true, 9 },
                    { 22, 11, 7, true, 9 },
                    { 23, 10, 4, true, 10 },
                    { 24, 8, 6, true, 10 },
                    { 25, 11, 7, true, 10 },
                    { 26, 27, 4, true, 11 },
                    { 27, 10, 4, true, 12 },
                    { 28, 11, 7, true, 12 },
                    { 29, 3, 4, true, 13 },
                    { 30, 4, 7, true, 14 },
                    { 31, 10, 4, true, 15 },
                    { 32, 22, 4, true, 16 },
                    { 33, 10, 4, true, 17 },
                    { 34, 11, 7, true, 18 },
                    { 35, 21, 0, true, 19 },
                    { 36, 1, 6, true, 20 },
                    { 37, 4, 7, true, 20 },
                    { 38, 13, 0, true, 21 },
                    { 39, 17, 0, true, 22 },
                    { 40, 21, 0, true, 23 },
                    { 41, 26, 0, true, 24 },
                    { 42, 21, 0, true, 25 },
                    { 43, 5, 0, true, 26 },
                    { 44, 13, 0, true, 27 },
                    { 45, 26, 0, true, 28 },
                    { 46, 5, 0, true, 29 },
                    { 47, 17, 0, true, 30 },
                    { 48, 21, 0, true, 31 },
                    { 49, 13, 0, true, 32 },
                    { 50, 26, 0, true, 33 },
                    { 51, 21, 0, true, 34 },
                    { 52, 17, 0, true, 35 },
                    { 53, 20, 12, true, 36 },
                    { 54, 25, 12, true, 37 },
                    { 55, 20, 9, true, 38 },
                    { 56, 6, 12, true, 39 },
                    { 57, 25, 12, true, 40 },
                    { 58, 20, 12, true, 41 },
                    { 59, 20, 12, true, 42 },
                    { 60, 25, 12, true, 43 },
                    { 61, 6, 9, true, 44 },
                    { 62, 20, 12, true, 45 },
                    { 63, 24, 10, true, 46 },
                    { 64, 7, 10, true, 47 },
                    { 65, 24, 10, true, 48 },
                    { 66, 7, 10, true, 49 },
                    { 67, 24, 10, true, 50 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //DON'T EVER ROLL THIS BACK. IT WILL BREAK THINGS.
        }
    }
}
