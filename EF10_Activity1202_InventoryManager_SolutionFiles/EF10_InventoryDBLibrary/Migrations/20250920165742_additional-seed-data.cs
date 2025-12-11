using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF10_InventoryDBLibrary.Migrations
{
    /// <inheritdoc />
    public partial class additionalseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contributors",
                columns: new[] { "Id", "ContributorName", "Description", "IsActive" },
                values: new object[,]
                {
                    { 13, "Frank Herbert", null, true },
                    { 14, "Denis Villeneuve", null, true },
                    { 15, "Timothée Chalamet", null, true },
                    { 16, "Zendaya", null, true },
                    { 17, "J.K. Rowling", null, true },
                    { 18, "Daniel Radcliffe", null, true },
                    { 19, "Chris Columbus", null, true },
                    { 20, "Blizzard Entertainment", null, true },
                    { 21, "Stephen King", null, true },
                    { 22, "Stanley Kubrick", null, true },
                    { 23, "Jack Nicholson", null, true },
                    { 24, "Funko", null, true },
                    { 25, "Rockstar Games", null, true },
                    { 26, "Agatha Christie", null, true },
                    { 27, "Kenneth Branagh", null, true }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Star Trek™: U.S.S. Enterprise: NCC-1701 Ornament");

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "CreatedByUserId", "CreatedDate", "CurrentValue", "Description", "IsActive", "LastModifiedDate", "LastModifiedUserId", "Name", "Notes", "PurchasePrice", "PurchasedDate", "Quantity", "SoldDate" },
                values: new object[,]
                {
                    { 6, 1, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Film adaptation of Frank Herbert's novel.", true, null, null, "Dune (2021)", null, null, null, 1, null },
                    { 7, 1, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "First Harry Potter movie.", true, null, null, "Harry Potter and the Sorcerer's Stone", null, null, null, 1, null },
                    { 8, 1, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Horror film based on Stephen King's book.", true, null, null, "The Shining", null, null, null, 1, null },
                    { 9, 1, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mind-bending thriller by Christopher Nolan.", true, null, null, "Inception", null, null, null, 1, null },
                    { 10, 1, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sequel to Batman Begins.", true, null, null, "The Dark Knight", null, null, null, 1, null },
                    { 11, 1, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adaptation of Agatha Christie's mystery.", true, null, null, "Murder on the Orient Express (2017)", null, null, null, 1, null },
                    { 12, 1, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sci-fi epic by Christopher Nolan.", true, null, null, "Interstellar", null, null, null, 1, null },
                    { 13, 1, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Groundbreaking action sci-fi film.", true, null, null, "The Matrix", null, null, null, 1, null },
                    { 14, 1, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adventure film with dinosaurs.", true, null, null, "Jurassic Park", null, null, null, 1, null },
                    { 15, 1, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Classic crime drama.", true, null, null, "The Godfather", null, null, null, 1, null },
                    { 16, 1, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Quentin Tarantino's nonlinear crime film.", true, null, null, "Pulp Fiction", null, null, null, 1, null },
                    { 17, 1, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Psychological thriller.", true, null, null, "Fight Club", null, null, null, 1, null },
                    { 18, 1, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Heartwarming drama.", true, null, null, "Forrest Gump", null, null, null, 1, null },
                    { 19, 1, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Prison drama based on Stephen King story.", true, null, null, "The Shawshank Redemption", null, null, null, 1, null },
                    { 20, 1, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sequel to A New Hope.", true, null, null, "The Empire Strikes Back", null, null, null, 1, null },
                    { 21, 2, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sci-fi novel by Frank Herbert (crossover with movie).", true, null, null, "Dune", null, null, null, 1, null },
                    { 22, 2, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "First Harry Potter book (crossover with movie).", true, null, null, "Harry Potter and the Sorcerer's Stone", null, null, null, 1, null },
                    { 23, 2, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Horror novel by Stephen King (crossover with movie).", true, null, null, "The Shining", null, null, null, 1, null },
                    { 24, 2, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mystery novel by Agatha Christie (crossover with movie).", true, null, null, "Murder on the Orient Express", null, null, null, 1, null },
                    { 25, 2, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Horror novel by Stephen King.", true, null, null, "It", null, null, null, 1, null },
                    { 26, 2, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fantasy prequel to Lord of the Rings.", true, null, null, "The Hobbit", null, null, null, 1, null },
                    { 27, 2, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dystopian classic by George Orwell.", true, null, null, "1984", null, null, null, 1, null },
                    { 28, 2, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Classic novel by Harper Lee.", true, null, null, "To Kill a Mockingbird", null, null, null, 1, null },
                    { 29, 2, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "F. Scott Fitzgerald's jazz age novel.", true, null, null, "The Great Gatsby", null, null, null, 1, null },
                    { 30, 2, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jane Austen's romantic classic.", true, null, null, "Pride and Prejudice", null, null, null, 1, null },
                    { 31, 2, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "J.D. Salinger's coming-of-age story.", true, null, null, "The Catcher in the Rye", null, null, null, 1, null },
                    { 32, 2, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Aldous Huxley's dystopian vision.", true, null, null, "Brave New World", null, null, null, 1, null },
                    { 33, 2, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dan Brown's thriller.", true, null, null, "The Da Vinci Code", null, null, null, 1, null },
                    { 34, 2, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gillian Flynn's psychological thriller.", true, null, null, "Gone Girl", null, null, null, 1, null },
                    { 35, 2, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Suzanne Collins' dystopian adventure.", true, null, null, "The Hunger Games", null, null, null, 1, null },
                    { 36, 3, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "MMORPG by Blizzard.", true, null, null, "World of Warcraft", null, null, null, 1, null },
                    { 37, 3, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Open-world action game by Rockstar.", true, null, null, "Grand Theft Auto V", null, null, null, 1, null },
                    { 38, 3, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Adventure game by Nintendo.", true, null, null, "The Legend of Zelda: Breath of the Wild", null, null, null, 1, null },
                    { 39, 3, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sandbox building game.", true, null, null, "Minecraft", null, null, null, 1, null },
                    { 40, 3, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Battle royale shooter.", true, null, null, "Fortnite", null, null, null, 1, null },
                    { 41, 3, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RPG based on Andrzej Sapkowski's books.", true, null, null, "The Witcher 3: Wild Hunt", null, null, null, 1, null },
                    { 42, 3, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Team-based shooter by Blizzard.", true, null, null, "Overwatch", null, null, null, 1, null },
                    { 43, 3, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sci-fi RPG by CD Projekt Red.", true, null, null, "Cyberpunk 2077", null, null, null, 1, null },
                    { 44, 3, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Historical action RPG.", true, null, null, "Assassin's Creed Valhalla", null, null, null, 1, null },
                    { 45, 3, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Platformer by Nintendo.", true, null, null, "Super Mario Odyssey", null, null, null, 1, null },
                    { 46, 4, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Collectible vinyl figure of Batman.", true, null, null, "Funko Pop! Batman", null, null, null, 1, null },
                    { 47, 4, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Collectible wand from the series.", true, null, null, "Harry Potter Wand Replica", null, null, null, 1, null },
                    { 48, 4, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Replica lightsaber.", true, null, null, "Star Wars Lightsaber Toy", null, null, null, 1, null },
                    { 49, 4, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "One Ring collectible.", true, null, null, "Lord of the Rings Ring Replica", null, null, null, 1, null },
                    { 50, 4, "2fd28110-93d0-427d-9207-d55dbca680fa", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Collectible figure from Dune.", true, null, null, "Dune Sandworm Figure", null, null, null, 1, null }
                });

            migrationBuilder.InsertData(
                table: "ItemContributors",
                columns: new[] { "Id", "ContributorId", "ContributorType", "ItemId" },
                values: new object[,]
                {
                    { 13, 14, "Director", 6 },
                    { 14, 15, "Actor", 6 },
                    { 15, 16, "Actor", 6 },
                    { 16, 11, "Composer", 6 },
                    { 17, 19, "Director", 7 },
                    { 18, 18, "Actor", 7 },
                    { 19, 22, "Director", 8 },
                    { 20, 23, "Actor", 8 },
                    { 21, 10, "Director", 9 },
                    { 22, 11, "Composer", 9 },
                    { 23, 10, "Director", 10 },
                    { 24, 8, "Actor", 10 },
                    { 25, 11, "Composer", 10 },
                    { 26, 27, "Director", 11 },
                    { 27, 10, "Director", 12 },
                    { 28, 11, "Composer", 12 },
                    { 29, 3, "Director", 13 },
                    { 30, 4, "Composer", 14 },
                    { 31, 10, "Director", 15 },
                    { 32, 22, "Director", 16 },
                    { 33, 10, "Director", 17 },
                    { 34, 11, "Composer", 18 },
                    { 35, 21, "Author", 19 },
                    { 36, 1, "Actor", 20 },
                    { 37, 4, "Composer", 20 },
                    { 38, 13, "Author", 21 },
                    { 39, 17, "Author", 22 },
                    { 40, 21, "Author", 23 },
                    { 41, 26, "Author", 24 },
                    { 42, 21, "Author", 25 },
                    { 43, 5, "Author", 26 },
                    { 44, 13, "Author", 27 },
                    { 45, 26, "Author", 28 },
                    { 46, 5, "Author", 29 },
                    { 47, 17, "Author", 30 },
                    { 48, 21, "Author", 31 },
                    { 49, 13, "Author", 32 },
                    { 50, 26, "Author", 33 },
                    { 51, 21, "Author", 34 },
                    { 52, 17, "Author", 35 },
                    { 53, 20, "Developer", 36 },
                    { 54, 25, "Developer", 37 },
                    { 55, 20, "Publisher", 38 },
                    { 56, 6, "Developer", 39 },
                    { 57, 25, "Developer", 40 },
                    { 58, 20, "Developer", 41 },
                    { 59, 20, "Developer", 42 },
                    { 60, 25, "Developer", 43 },
                    { 61, 6, "Publisher", 44 },
                    { 62, 20, "Developer", 45 },
                    { 63, 24, "Manufacturer", 46 },
                    { 64, 7, "Manufacturer", 47 },
                    { 65, 24, "Manufacturer", 48 },
                    { 66, 7, "Manufacturer", 49 },
                    { 67, 24, "Manufacturer", 50 }
                });

            migrationBuilder.InsertData(
                table: "ItemGenres",
                columns: new[] { "GenreId", "ItemId" },
                values: new object[,]
                {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 8, 10 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 9, 10 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 5, 11 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 7, 11 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 9, 12 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 8, 13 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 3, 14 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 9, 15 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 5, 16 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 9, 16 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 5, 17 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 9, 17 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 4, 18 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 9, 18 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 4, 19 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 9, 19 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 8, 20 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 1, 21 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 3, 21 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 4, 21 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 2, 22 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 3, 22 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 5, 23 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 6, 23 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 4, 24 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 7, 24 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 6, 25 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 2, 26 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 3, 26 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 1, 27 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 4, 27 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 4, 28 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 9, 28 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 4, 29 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 9, 29 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 4, 30 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 9, 30 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 4, 31 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 9, 31 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 1, 32 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 4, 32 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 5, 33 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 7, 33 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 5, 34 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 7, 34 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 1, 35 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 3, 35 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 2, 36 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 3, 36 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 3, 37 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 8, 37 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 2, 38 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 3, 38 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 3, 39 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 8, 40 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 2, 41 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 3, 41 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 1, 42 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 8, 42 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 1, 43 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 8, 43 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 3, 44 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 8, 44 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 3, 45 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 10, 46 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 11, 46 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 2, 47 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 11, 47 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 1, 48 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 11, 48 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 2, 49 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 11, 49 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 1, 50 });

            migrationBuilder.DeleteData(
                table: "ItemGenres",
                keyColumns: new[] { "GenreId", "ItemId" },
                keyValues: new object[] { 11, 50 });

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Contributors",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Star Trek: U.S.S. Enterprise: NCC-1701 Ornament");
        }
    }
}
