using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF10_NewFeaturesDbLibrary.Migrations
{
    /// <inheritdoc />
    public partial class fixtheitemgenreimplicitnamingandseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreItem");

            migrationBuilder.CreateTable(
                name: "ItemGenres",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGenres", x => new { x.ItemId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_ItemGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemGenres_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ItemGenres",
                columns: new[] { "GenreId", "ItemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 8, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 8, 3 },
                    { 11, 4 },
                    { 8, 5 },
                    { 9, 5 },
                    { 10, 5 },
                    { 1, 6 },
                    { 3, 6 },
                    { 2, 7 },
                    { 3, 7 },
                    { 5, 8 },
                    { 6, 8 },
                    { 1, 9 },
                    { 5, 9 },
                    { 8, 10 },
                    { 9, 10 },
                    { 10, 10 },
                    { 5, 11 },
                    { 7, 11 },
                    { 1, 12 },
                    { 9, 12 },
                    { 1, 13 },
                    { 8, 13 },
                    { 1, 14 },
                    { 3, 14 },
                    { 4, 15 },
                    { 9, 15 },
                    { 5, 16 },
                    { 9, 16 },
                    { 5, 17 },
                    { 9, 17 },
                    { 4, 18 },
                    { 9, 18 },
                    { 4, 19 },
                    { 9, 19 },
                    { 1, 20 },
                    { 8, 20 },
                    { 1, 21 },
                    { 3, 21 },
                    { 4, 21 },
                    { 2, 22 },
                    { 3, 22 },
                    { 5, 23 },
                    { 6, 23 },
                    { 4, 24 },
                    { 7, 24 },
                    { 6, 25 },
                    { 2, 26 },
                    { 3, 26 },
                    { 1, 27 },
                    { 4, 27 },
                    { 4, 28 },
                    { 9, 28 },
                    { 4, 29 },
                    { 9, 29 },
                    { 4, 30 },
                    { 9, 30 },
                    { 4, 31 },
                    { 9, 31 },
                    { 1, 32 },
                    { 4, 32 },
                    { 5, 33 },
                    { 7, 33 },
                    { 5, 34 },
                    { 7, 34 },
                    { 1, 35 },
                    { 3, 35 },
                    { 2, 36 },
                    { 3, 36 },
                    { 3, 37 },
                    { 8, 37 },
                    { 2, 38 },
                    { 3, 38 },
                    { 3, 39 },
                    { 8, 40 },
                    { 2, 41 },
                    { 3, 41 },
                    { 1, 42 },
                    { 8, 42 },
                    { 1, 43 },
                    { 8, 43 },
                    { 3, 44 },
                    { 8, 44 },
                    { 3, 45 },
                    { 10, 46 },
                    { 11, 46 },
                    { 2, 47 },
                    { 11, 47 },
                    { 1, 48 },
                    { 11, 48 },
                    { 2, 49 },
                    { 11, 49 },
                    { 1, 50 },
                    { 11, 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemGenres_GenreId",
                table: "ItemGenres",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //DO NOT EVER ROLL THIS BACK. IT COULD BREAK THINGS.
        }
    }
}
