using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF10_InventoryDBLibrary.Migrations
{
    /// <inheritdoc />
    public partial class seedinitialdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "Description", "IsActive" },
                values: new object[,]
                {
                    { 1, "Movie", "Film or motion picture", true },
                    { 2, "Book", "Printed or written literary work", true },
                    { 3, "Game", "Interactive entertainment", true },
                    { 4, "Toy/Collectable", "Physical toy or collectible", true }
                });

            migrationBuilder.InsertData(
                table: "Contributors",
                columns: new[] { "Id", "ContributorName", "Description", "IsActive" },
                values: new object[,]
                {
                    { 1, "Harrison Ford", null, true },
                    { 2, "Carrie Fisher", null, true },
                    { 3, "George Lucas", null, true },
                    { 4, "John Williams", null, true },
                    { 5, "J.R.R. Tolkien", null, true },
                    { 6, "Wargaming", null, true },
                    { 7, "Hallmark", null, true },
                    { 8, "Christian Bale", null, true },
                    { 9, "Katie Holmes", null, true },
                    { 10, "Christopher Nolan", null, true },
                    { 11, "Hans Zimmer", null, true },
                    { 12, "James Newton Howard", null, true }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName", "IsActive" },
                values: new object[,]
                {
                    { 1, "Science Fiction", true },
                    { 2, "Fantasy", true },
                    { 3, "Adventure", true },
                    { 4, "Classic", true },
                    { 5, "Thriller", true },
                    { 6, "Horror", true },
                    { 7, "Mystery", true },
                    { 8, "Action", true },
                    { 9, "Drama", true },
                    { 10, "Superhero", true },
                    { 11, "Collectible", true }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "CreatedByUserId", "CreatedDate", "CurrentValue", "Description", "IsActive", "LastModifiedDate", "LastModifiedUserId", "Name", "Notes", "PurchasePrice", "PurchasedDate", "Quantity", "SoldDate" },
                values: new object[,]
                {
                    { 1, 1, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The original Star Wars movie.", true, null, null, "Star Wars: A New Hope", null, null, null, 1, null },
                    { 2, 2, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Classic fantasy novel by J.R.R. Tolkien.", true, null, null, "The Lord of the Rings: The Fellowship of the Ring", null, null, null, 1, null },
                    { 3, 3, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Popular online multiplayer tank game.", true, null, null, "World of Tanks", null, null, null, 1, null },
                    { 4, 4, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Collectible Hallmark ornament.", true, null, null, "Star Trek: U.S.S. Enterprise: NCC-1701 Ornament", null, null, null, 1, null },
                    { 5, 1, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Christopher Nolan's Batman movie.", true, null, null, "Batman Begins", null, null, null, 1, null }
                });

            migrationBuilder.InsertData(
                table: "ItemContributors",
                columns: new[] { "Id", "ContributorId", "ContributorType", "ItemId" },
                values: new object[,]
                {
                    { 1, 1, "Actor", 1 },
                    { 2, 2, "Actor", 1 },
                    { 3, 3, "Director", 1 },
                    { 4, 4, "Composer", 1 },
                    { 5, 5, "Author", 2 },
                    { 6, 6, "Publisher", 3 },
                    { 7, 7, "Manufacturer", 4 },
                    { 8, 8, "Actor", 5 },
                    { 9, 9, "Actor", 5 },
                    { 10, 10, "Director", 5 },
                    { 11, 11, "Composer", 5 },
                    { 12, 12, "Composer", 5 }
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
                    { 10, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
