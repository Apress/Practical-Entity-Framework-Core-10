using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF10_NewFeaturesDbLibrary.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
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
                columns: new[] { "Id", "ContributorName", "IsActive" },
                values: new object[,]
                {
                    { 1, "Harrison Ford", true },
                    { 2, "Carrie Fisher", true },
                    { 3, "George Lucas", true },
                    { 4, "John Williams", true },
                    { 5, "J.R.R. Tolkien", true },
                    { 6, "Wargaming", true },
                    { 7, "Hallmark", true },
                    { 8, "Christian Bale", true },
                    { 9, "Katie Holmes", true },
                    { 10, "Christopher Nolan", true },
                    { 11, "Hans Zimmer", true },
                    { 12, "James Newton Howard", true },
                    { 13, "Frank Herbert", true },
                    { 14, "Denis Villeneuve", true },
                    { 15, "Timothée Chalamet", true },
                    { 16, "Zendaya", true },
                    { 17, "J.K. Rowling", true },
                    { 18, "Daniel Radcliffe", true },
                    { 19, "Chris Columbus", true },
                    { 20, "Blizzard Entertainment", true },
                    { 21, "Stephen King", true },
                    { 22, "Stanley Kubrick", true },
                    { 23, "Jack Nicholson", true },
                    { 24, "Funko", true },
                    { 25, "Rockstar Games", true },
                    { 26, "Agatha Christie", true },
                    { 27, "Kenneth Branagh", true }
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
                table: "Tenant",
                columns: new[] { "Id", "IsActive", "TenantName" },
                values: new object[,]
                {
                    { 1, true, "Default Tenant" },
                    { 2, true, "Another Tenant" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "IsActive", "ItemName", "TenantId" },
                values: new object[,]
                {
                    { 1, 1, "The original Star Wars movie.", true, "Star Wars: A New Hope", 1 },
                    { 2, 2, "Classic fantasy novel by J.R.R. Tolkien.", true, "The Lord of the Rings: The Fellowship of the Ring", 1 },
                    { 3, 3, "Popular online multiplayer tank game.", true, "World of Tanks", 1 },
                    { 4, 4, "Collectible Hallmark ornament.", true, "Star Trek™: U.S.S. Enterprise: NCC-1701 Ornament", 1 },
                    { 5, 1, "Christopher Nolan's Batman movie.", true, "Batman Begins", 1 },
                    { 6, 1, "Film adaptation of Frank Herbert's novel.", true, "Dune (2021)", 1 },
                    { 7, 1, "First Harry Potter movie.", true, "Harry Potter and the Sorcerer's Stone", 1 },
                    { 8, 1, "Horror film based on Stephen King's book.", true, "The Shining", 1 },
                    { 9, 1, "Mind-bending thriller by Christopher Nolan.", true, "Inception", 1 },
                    { 10, 1, "Sequel to Batman Begins.", true, "The Dark Knight", 1 },
                    { 11, 1, "Adaptation of Agatha Christie's mystery.", true, "Murder on the Orient Express (2017)", 1 },
                    { 12, 1, "Sci-fi epic by Christopher Nolan.", true, "Interstellar", 1 },
                    { 13, 1, "Groundbreaking action sci-fi film.", true, "The Matrix", 1 },
                    { 14, 1, "Adventure film with dinosaurs.", true, "Jurassic Park", 1 },
                    { 15, 1, "Classic crime drama.", true, "The Godfather", 1 },
                    { 16, 1, "Quentin Tarantino's nonlinear crime film.", true, "Pulp Fiction", 1 },
                    { 17, 1, "Psychological thriller.", true, "Fight Club", 1 },
                    { 18, 1, "Heartwarming drama.", true, "Forrest Gump", 1 },
                    { 19, 1, "Prison drama based on Stephen King story.", true, "The Shawshank Redemption", 1 },
                    { 20, 1, "Sequel to A New Hope.", true, "The Empire Strikes Back", 1 },
                    { 21, 2, "Sci-fi novel by Frank Herbert (crossover with movie).", true, "Dune", 1 },
                    { 22, 2, "First Harry Potter book (crossover with movie).", true, "Harry Potter and the Sorcerer's Stone", 1 },
                    { 23, 2, "Horror novel by Stephen King (crossover with movie).", true, "The Shining", 1 },
                    { 24, 2, "Mystery novel by Agatha Christie (crossover with movie).", true, "Murder on the Orient Express", 1 },
                    { 25, 2, "Horror novel by Stephen King.", true, "It", 1 },
                    { 26, 2, "Fantasy prequel to Lord of the Rings.", true, "The Hobbit", 1 },
                    { 27, 2, "Dystopian classic by George Orwell.", true, "1984", 1 },
                    { 28, 2, "Classic novel by Harper Lee.", true, "To Kill a Mockingbird", 1 },
                    { 29, 2, "F. Scott Fitzgerald's jazz age novel.", true, "The Great Gatsby", 1 },
                    { 30, 2, "Jane Austen's romantic classic.", true, "Pride and Prejudice", 1 },
                    { 31, 2, "J.D. Salinger's coming-of-age story.", true, "The Catcher in the Rye", 1 },
                    { 32, 2, "Aldous Huxley's dystopian vision.", true, "Brave New World", 1 },
                    { 33, 2, "Dan Brown's thriller.", true, "The Da Vinci Code", 1 },
                    { 34, 2, "Gillian Flynn's psychological thriller.", true, "Gone Girl", 1 },
                    { 35, 2, "Suzanne Collins' dystopian adventure.", true, "The Hunger Games", 1 },
                    { 36, 3, "MMORPG by Blizzard.", true, "World of Warcraft", 1 },
                    { 37, 3, "Open-world action game by Rockstar.", true, "Grand Theft Auto V", 1 },
                    { 38, 3, "Adventure game by Nintendo.", true, "The Legend of Zelda: Breath of the Wild", 1 },
                    { 39, 3, "Sandbox building game.", true, "Minecraft", 1 },
                    { 40, 3, "Battle royale shooter.", true, "Fortnite", 1 },
                    { 41, 3, "RPG based on Andrzej Sapkowski's books.", true, "The Witcher 3: Wild Hunt", 1 },
                    { 42, 3, "Team-based shooter by Blizzard.", true, "Overwatch", 1 },
                    { 43, 3, "Sci-fi RPG by CD Projekt Red.", true, "Cyberpunk 2077", 1 },
                    { 44, 3, "Historical action RPG.", true, "Assassin's Creed Valhalla", 1 },
                    { 45, 3, "Platformer by Nintendo.", true, "Super Mario Odyssey", 1 },
                    { 46, 4, "Collectible vinyl figure of Batman.", true, "Funko Pop! Batman", 1 },
                    { 47, 4, "Collectible wand from the series.", true, "Harry Potter Wand Replica", 1 },
                    { 48, 4, "Replica lightsaber.", true, "Star Wars Lightsaber Toy", 1 },
                    { 49, 4, "One Ring collectible.", true, "Lord of the Rings Ring Replica", 1 },
                    { 50, 4, "Collectible figure from Dune.", true, "Dune Sandworm Figure", 1 }
                });

            migrationBuilder.InsertData(
                table: "ItemContributors",
                columns: new[] { "ContributorId", "ItemId", "ContributorType", "Id", "IsActive" },
                values: new object[,]
                {
                    { 1, 1, 6, 1, true },
                    { 2, 1, 6, 2, true },
                    { 3, 1, 4, 3, true },
                    { 4, 1, 7, 4, true },
                    { 5, 2, 0, 5, true },
                    { 6, 3, 9, 6, true },
                    { 7, 4, 10, 7, true },
                    { 8, 5, 6, 8, true },
                    { 9, 5, 6, 9, true },
                    { 10, 5, 4, 10, true },
                    { 11, 5, 7, 11, true },
                    { 12, 5, 7, 12, true },
                    { 11, 6, 7, 16, true },
                    { 14, 6, 4, 13, true },
                    { 15, 6, 6, 14, true },
                    { 16, 6, 6, 15, true },
                    { 18, 7, 6, 18, true },
                    { 19, 7, 4, 17, true },
                    { 22, 8, 4, 19, true },
                    { 23, 8, 6, 20, true },
                    { 10, 9, 4, 21, true },
                    { 11, 9, 7, 22, true },
                    { 8, 10, 6, 24, true },
                    { 10, 10, 4, 23, true },
                    { 11, 10, 7, 25, true },
                    { 27, 11, 4, 26, true },
                    { 10, 12, 4, 27, true },
                    { 11, 12, 7, 28, true },
                    { 3, 13, 4, 29, true },
                    { 4, 14, 7, 30, true },
                    { 10, 15, 4, 31, true },
                    { 22, 16, 4, 32, true },
                    { 10, 17, 4, 33, true },
                    { 11, 18, 7, 34, true },
                    { 21, 19, 0, 35, true },
                    { 1, 20, 6, 36, true },
                    { 4, 20, 7, 37, true },
                    { 13, 21, 0, 38, true },
                    { 17, 22, 0, 39, true },
                    { 21, 23, 0, 40, true },
                    { 26, 24, 0, 41, true },
                    { 21, 25, 0, 42, true },
                    { 5, 26, 0, 43, true },
                    { 13, 27, 0, 44, true },
                    { 26, 28, 0, 45, true },
                    { 5, 29, 0, 46, true },
                    { 17, 30, 0, 47, true },
                    { 21, 31, 0, 48, true },
                    { 13, 32, 0, 49, true },
                    { 26, 33, 0, 50, true },
                    { 21, 34, 0, 51, true },
                    { 17, 35, 0, 52, true },
                    { 20, 36, 12, 53, true },
                    { 25, 37, 12, 54, true },
                    { 20, 38, 9, 55, true },
                    { 6, 39, 12, 56, true },
                    { 25, 40, 12, 57, true },
                    { 20, 41, 12, 58, true },
                    { 20, 42, 12, 59, true },
                    { 25, 43, 12, 60, true },
                    { 6, 44, 9, 61, true },
                    { 20, 45, 12, 62, true },
                    { 24, 46, 10, 63, true },
                    { 7, 47, 10, 64, true },
                    { 24, 48, 10, 65, true },
                    { 7, 49, 10, 66, true },
                    { 24, 50, 10, 67, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_TenantId",
                table: "Items",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Tenant_TenantId",
                table: "Items",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Tenant_TenantId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_TenantId",
                table: "Items");

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
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 11, 5 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 12, 5 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 11, 6 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 14, 6 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 15, 6 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 16, 6 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 18, 7 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 19, 7 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 22, 8 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 23, 8 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 10, 9 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 11, 9 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 8, 10 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 11, 10 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 27, 11 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 10, 12 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 11, 12 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 4, 14 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 10, 15 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 22, 16 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 10, 17 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 11, 18 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 21, 19 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 4, 20 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 13, 21 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 17, 22 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 21, 23 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 26, 24 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 21, 25 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 5, 26 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 13, 27 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 26, 28 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 5, 29 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 17, 30 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 21, 31 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 13, 32 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 26, 33 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 21, 34 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 17, 35 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 20, 36 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 25, 37 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 20, 38 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 6, 39 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 25, 40 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 20, 41 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 20, 42 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 25, 43 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 6, 44 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 20, 45 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 24, 46 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 7, 47 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 24, 48 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 7, 49 });

            migrationBuilder.DeleteData(
                table: "ItemContributors",
                keyColumns: new[] { "ContributorId", "ItemId" },
                keyValues: new object[] { 24, 50 });

            migrationBuilder.DeleteData(
                table: "Tenant",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.DeleteData(
                table: "Tenant",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
