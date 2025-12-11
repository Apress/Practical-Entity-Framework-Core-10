using EF10_InventoryModels;

namespace EF10_InventoryDBLibrary.Seeding;

public class SeedData
{
    private static string _systemUserId = "2fd28110-93d0-427d-9207-d55dbca680fa";
    private static DateTime _seedItemCreatedDate = new DateTime(2025, 11, 01);

    public static Category[] Categories = new[]
    {
        new Category { Id = 1, CategoryName = "Movie", Description = "Film or motion picture" },
        new Category { Id = 2, CategoryName = "Book", Description = "Printed or written literary work" },
        new Category { Id = 3, CategoryName = "Game", Description = "Interactive entertainment" },
        new Category { Id = 4, CategoryName = "Toy/Collectable", Description = "Physical toy or collectible" }
    };

    public static Genre[] Genres = new[]
    {
        new Genre { Id = 1, GenreName = "Science Fiction" },
        new Genre { Id = 2, GenreName = "Fantasy" },
        new Genre { Id = 3, GenreName = "Adventure" },
        new Genre { Id = 4, GenreName = "Classic" },
        new Genre { Id = 5, GenreName = "Thriller" },
        new Genre { Id = 6, GenreName = "Horror" },
        new Genre { Id = 7, GenreName = "Mystery" },
        new Genre { Id = 8, GenreName = "Action" },
        new Genre { Id = 9, GenreName = "Drama" },
        new Genre { Id = 10, GenreName = "Superhero" },
        new Genre { Id = 11, GenreName = "Collectible" }
    };

    public static Contributor[] Contributors = new[]
    {
        new Contributor { Id = 1, ContributorName = "Harrison Ford" },
        new Contributor { Id = 2, ContributorName = "Carrie Fisher" },
        new Contributor { Id = 3, ContributorName = "George Lucas" },
        new Contributor { Id = 4, ContributorName = "John Williams" },
        new Contributor { Id = 5, ContributorName = "J.R.R. Tolkien" },
        new Contributor { Id = 6, ContributorName = "Wargaming" },
        new Contributor { Id = 7, ContributorName = "Hallmark" },
        new Contributor { Id = 8, ContributorName = "Christian Bale" },
        new Contributor { Id = 9, ContributorName = "Katie Holmes" },
        new Contributor { Id = 10, ContributorName = "Christopher Nolan" },
        new Contributor { Id = 11, ContributorName = "Hans Zimmer" },
        new Contributor { Id = 12, ContributorName = "James Newton Howard" },
        // Additional contributors (15 more for variety)
        new Contributor { Id = 13, ContributorName = "Frank Herbert" }, // Author for Dune
        new Contributor { Id = 14, ContributorName = "Denis Villeneuve" }, // Director for Dune movie
        new Contributor { Id = 15, ContributorName = "Timothée Chalamet" }, // Actor in Dune
        new Contributor { Id = 16, ContributorName = "Zendaya" }, // Actor in Dune
        new Contributor { Id = 17, ContributorName = "J.K. Rowling" }, // Author for Harry Potter
        new Contributor { Id = 18, ContributorName = "Daniel Radcliffe" }, // Actor in Harry Potter
        new Contributor { Id = 19, ContributorName = "Chris Columbus" }, // Director for Harry Potter movie
        new Contributor { Id = 20, ContributorName = "Blizzard Entertainment" }, // Developer/Publisher for games
        new Contributor { Id = 21, ContributorName = "Stephen King" }, // Author for horror books
        new Contributor { Id = 22, ContributorName = "Stanley Kubrick" }, // Director for The Shining
        new Contributor { Id = 23, ContributorName = "Jack Nicholson" }, // Actor in The Shining
        new Contributor { Id = 24, ContributorName = "Funko" }, // Manufacturer for collectibles
        new Contributor { Id = 25, ContributorName = "Rockstar Games" }, // Developer for GTA
        new Contributor { Id = 26, ContributorName = "Agatha Christie" }, // Author for mysteries
        new Contributor { Id = 27, ContributorName = "Kenneth Branagh" } // Director/Actor for Poirot adaptations
    };

    public static Item[] Items = new[]
    {
        new Item { Id = 1, Name = "Star Wars: A New Hope", Quantity = 1, CategoryId = 1, Description = "The original Star Wars movie.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 2, Name = "The Lord of the Rings: The Fellowship of the Ring", Quantity = 1, CategoryId = 2, Description = "Classic fantasy novel by J.R.R. Tolkien.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 3, Name = "World of Tanks", Quantity = 1, CategoryId = 3, Description = "Popular online multiplayer tank game.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 4, Name = "Star Trek™: U.S.S. Enterprise: NCC-1701 Ornament", Quantity = 1, CategoryId = 4, Description = "Collectible Hallmark ornament.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 5, Name = "Batman Begins", Quantity = 1, CategoryId = 1, Description = "Christopher Nolan's Batman movie.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        // Additional items to reach ~50 total (45 more across categories, with some crossovers like book/movie adaptations)
        // Movies (adding 15 more for total ~20 movies)
        new Item { Id = 6, Name = "Dune (2021)", Quantity = 1, CategoryId = 1, Description = "Film adaptation of Frank Herbert's novel.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 7, Name = "Harry Potter and the Sorcerer's Stone", Quantity = 1, CategoryId = 1, Description = "First Harry Potter movie.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 8, Name = "The Shining", Quantity = 1, CategoryId = 1, Description = "Horror film based on Stephen King's book.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 9, Name = "Inception", Quantity = 1, CategoryId = 1, Description = "Mind-bending thriller by Christopher Nolan.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 10, Name = "The Dark Knight", Quantity = 1, CategoryId = 1, Description = "Sequel to Batman Begins.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 11, Name = "Murder on the Orient Express (2017)", Quantity = 1, CategoryId = 1, Description = "Adaptation of Agatha Christie's mystery.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 12, Name = "Interstellar", Quantity = 1, CategoryId = 1, Description = "Sci-fi epic by Christopher Nolan.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 13, Name = "The Matrix", Quantity = 1, CategoryId = 1, Description = "Groundbreaking action sci-fi film.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 14, Name = "Jurassic Park", Quantity = 1, CategoryId = 1, Description = "Adventure film with dinosaurs.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 15, Name = "The Godfather", Quantity = 1, CategoryId = 1, Description = "Classic crime drama.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 16, Name = "Pulp Fiction", Quantity = 1, CategoryId = 1, Description = "Quentin Tarantino's nonlinear crime film.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 17, Name = "Fight Club", Quantity = 1, CategoryId = 1, Description = "Psychological thriller.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 18, Name = "Forrest Gump", Quantity = 1, CategoryId = 1, Description = "Heartwarming drama.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 19, Name = "The Shawshank Redemption", Quantity = 1, CategoryId = 1, Description = "Prison drama based on Stephen King story.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 20, Name = "The Empire Strikes Back", Quantity = 1, CategoryId = 1, Description = "Sequel to A New Hope.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        // Books (adding 15 more for total ~16 books, including crossovers)
        new Item { Id = 21, Name = "Dune", Quantity = 1, CategoryId = 2, Description = "Sci-fi novel by Frank Herbert (crossover with movie).", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 22, Name = "Harry Potter and the Sorcerer's Stone", Quantity = 1, CategoryId = 2, Description = "First Harry Potter book (crossover with movie).", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 23, Name = "The Shining", Quantity = 1, CategoryId = 2, Description = "Horror novel by Stephen King (crossover with movie).", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 24, Name = "Murder on the Orient Express", Quantity = 1, CategoryId = 2, Description = "Mystery novel by Agatha Christie (crossover with movie).", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 25, Name = "It", Quantity = 1, CategoryId = 2, Description = "Horror novel by Stephen King.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 26, Name = "The Hobbit", Quantity = 1, CategoryId = 2, Description = "Fantasy prequel to Lord of the Rings.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 27, Name = "1984", Quantity = 1, CategoryId = 2, Description = "Dystopian classic by George Orwell.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 28, Name = "To Kill a Mockingbird", Quantity = 1, CategoryId = 2, Description = "Classic novel by Harper Lee.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 29, Name = "The Great Gatsby", Quantity = 1, CategoryId = 2, Description = "F. Scott Fitzgerald's jazz age novel.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 30, Name = "Pride and Prejudice", Quantity = 1, CategoryId = 2, Description = "Jane Austen's romantic classic.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 31, Name = "The Catcher in the Rye", Quantity = 1, CategoryId = 2, Description = "J.D. Salinger's coming-of-age story.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 32, Name = "Brave New World", Quantity = 1, CategoryId = 2, Description = "Aldous Huxley's dystopian vision.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 33, Name = "The Da Vinci Code", Quantity = 1, CategoryId = 2, Description = "Dan Brown's thriller.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 34, Name = "Gone Girl", Quantity = 1, CategoryId = 2, Description = "Gillian Flynn's psychological thriller.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 35, Name = "The Hunger Games", Quantity = 1, CategoryId = 2, Description = "Suzanne Collins' dystopian adventure.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        // Games (adding 10 more for total ~11 games)
        new Item { Id = 36, Name = "World of Warcraft", Quantity = 1, CategoryId = 3, Description = "MMORPG by Blizzard.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 37, Name = "Grand Theft Auto V", Quantity = 1, CategoryId = 3, Description = "Open-world action game by Rockstar.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 38, Name = "The Legend of Zelda: Breath of the Wild", Quantity = 1, CategoryId = 3, Description = "Adventure game by Nintendo.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 39, Name = "Minecraft", Quantity = 1, CategoryId = 3, Description = "Sandbox building game.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 40, Name = "Fortnite", Quantity = 1, CategoryId = 3, Description = "Battle royale shooter.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 41, Name = "The Witcher 3: Wild Hunt", Quantity = 1, CategoryId = 3, Description = "RPG based on Andrzej Sapkowski's books.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 42, Name = "Overwatch", Quantity = 1, CategoryId = 3, Description = "Team-based shooter by Blizzard.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 43, Name = "Cyberpunk 2077", Quantity = 1, CategoryId = 3, Description = "Sci-fi RPG by CD Projekt Red.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 44, Name = "Assassin's Creed Valhalla", Quantity = 1, CategoryId = 3, Description = "Historical action RPG.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 45, Name = "Super Mario Odyssey", Quantity = 1, CategoryId = 3, Description = "Platformer by Nintendo.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        // Toys/Collectables (adding 5 more for total ~9 collectables)
        new Item { Id = 46, Name = "Funko Pop! Batman", Quantity = 1, CategoryId = 4, Description = "Collectible vinyl figure of Batman.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 47, Name = "Harry Potter Wand Replica", Quantity = 1, CategoryId = 4, Description = "Collectible wand from the series.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 48, Name = "Star Wars Lightsaber Toy", Quantity = 1, CategoryId = 4, Description = "Replica lightsaber.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 49, Name = "Lord of the Rings Ring Replica", Quantity = 1, CategoryId = 4, Description = "One Ring collectible.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 50, Name = "Dune Sandworm Figure", Quantity = 1, CategoryId = 4, Description = "Collectible figure from Dune.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate }
    };

    public static ItemContributor[] ItemContributors = new[]
    {
        // Existing
        // Star Wars: A New Hope (Movie)
        new ItemContributor { Id = 1, ItemId = 1, ContributorId = 1, ContributorType = ContributorType.Actor },
        new ItemContributor { Id = 2, ItemId = 1, ContributorId = 2, ContributorType = ContributorType.Actor },
        new ItemContributor { Id = 3, ItemId = 1, ContributorId = 3, ContributorType = ContributorType.Director },
        new ItemContributor { Id = 4, ItemId = 1, ContributorId = 4, ContributorType = ContributorType.Composer },

        // The Lord of the Rings: The Fellowship of the Ring (Book)
        new ItemContributor { Id = 5, ItemId = 2, ContributorId = 5, ContributorType = ContributorType.Author },

        // World of Tanks (Game)
        new ItemContributor { Id = 6, ItemId = 3, ContributorId = 6, ContributorType = ContributorType.Publisher },

        // Star Trek Ornament (Toy/Collectable)
        new ItemContributor { Id = 7, ItemId = 4, ContributorId = 7, ContributorType = ContributorType.Manufacturer },

        // Batman Begins (Movie)
        new ItemContributor { Id = 8, ItemId = 5, ContributorId = 8, ContributorType = ContributorType.Actor },
        new ItemContributor { Id = 9, ItemId = 5, ContributorId = 9, ContributorType = ContributorType.Actor },
        new ItemContributor { Id = 10, ItemId = 5, ContributorId = 10, ContributorType = ContributorType.Director },
        new ItemContributor { Id = 11, ItemId = 5, ContributorId = 11, ContributorType = ContributorType.Composer },
        new ItemContributor { Id = 12, ItemId = 5, ContributorId = 12, ContributorType = ContributorType.Composer },
        // Additional joins (using new and existing contributors, with crossovers)
        // Dune (Movie)
        new ItemContributor { Id = 13, ItemId = 6, ContributorId = 14, ContributorType = ContributorType.Director },
        new ItemContributor { Id = 14, ItemId = 6, ContributorId = 15, ContributorType = ContributorType.Actor },
        new ItemContributor { Id = 15, ItemId = 6, ContributorId = 16, ContributorType = ContributorType.Actor },
        new ItemContributor { Id = 16, ItemId = 6, ContributorId = 11, ContributorType = ContributorType.Composer }, // Hans Zimmer crossover
        // Harry Potter Movie
        new ItemContributor { Id = 17, ItemId = 7, ContributorId = 19, ContributorType = ContributorType.Director },
        new ItemContributor { Id = 18, ItemId = 7, ContributorId = 18, ContributorType = ContributorType.Actor },
        // The Shining Movie
        new ItemContributor { Id = 19, ItemId = 8, ContributorId = 22, ContributorType = ContributorType.Director },
        new ItemContributor { Id = 20, ItemId = 8, ContributorId = 23, ContributorType = ContributorType.Actor },
        // Inception Movie (crossover with Nolan)
        new ItemContributor { Id = 21, ItemId = 9, ContributorId = 10, ContributorType = ContributorType.Director },
        new ItemContributor { Id = 22, ItemId = 9, ContributorId = 11, ContributorType = ContributorType.Composer },
        // The Dark Knight Movie (crossover with Nolan/Bale)
        new ItemContributor { Id = 23, ItemId = 10, ContributorId = 10, ContributorType = ContributorType.Director },
        new ItemContributor { Id = 24, ItemId = 10, ContributorId = 8, ContributorType = ContributorType.Actor },
        new ItemContributor { Id = 25, ItemId = 10, ContributorId = 11, ContributorType = ContributorType.Composer },
        // Murder on the Orient Express Movie
        new ItemContributor { Id = 26, ItemId = 11, ContributorId = 27, ContributorType = ContributorType.Director },
        // Interstellar Movie (Nolan crossover)
        new ItemContributor { Id = 27, ItemId = 12, ContributorId = 10, ContributorType = ContributorType.Director },
        new ItemContributor { Id = 28, ItemId = 12, ContributorId = 11, ContributorType = ContributorType.Composer },
        // The Matrix (using new for variety, but could add more)
        new ItemContributor { Id = 29, ItemId = 13, ContributorId = 3, ContributorType = ContributorType.Director }, // Hypothetical crossover, but actually Wachowskis - using existing for demo
        // Jurassic Park (Spielberg, but using existing)
        new ItemContributor { Id = 30, ItemId = 14, ContributorId = 4, ContributorType = ContributorType.Composer }, // John Williams crossover
        // The Godfather (Coppola, using existing pattern)
        new ItemContributor { Id = 31, ItemId = 15, ContributorId = 10, ContributorType = ContributorType.Director }, // Hypothetical
        // Pulp Fiction
        new ItemContributor { Id = 32, ItemId = 16, ContributorId = 22, ContributorType = ContributorType.Director }, // Hypothetical
        // Fight Club
        new ItemContributor { Id = 33, ItemId = 17, ContributorId = 10, ContributorType = ContributorType.Director }, // Hypothetical
        // Forrest Gump
        new ItemContributor { Id = 34, ItemId = 18, ContributorId = 11, ContributorType = ContributorType.Composer }, // Hypothetical
        // Shawshank Redemption (crossover with King)
        new ItemContributor { Id = 35, ItemId = 19, ContributorId = 21, ContributorType = ContributorType.Author }, // Based on his novella
        // Empire Strikes Back (crossover with Star Wars)
        new ItemContributor { Id = 36, ItemId = 20, ContributorId = 1, ContributorType = ContributorType.Actor },
        new ItemContributor { Id = 37, ItemId = 20, ContributorId = 4, ContributorType = ContributorType.Composer },
        // Books
        // Dune Book (crossover)
        new ItemContributor { Id = 38, ItemId = 21, ContributorId = 13, ContributorType = ContributorType.Author },
        // Harry Potter Book (crossover)
        new ItemContributor { Id = 39, ItemId = 22, ContributorId = 17, ContributorType = ContributorType.Author },
        // The Shining Book (crossover)
        new ItemContributor { Id = 40, ItemId = 23, ContributorId = 21, ContributorType = ContributorType.Author },
        // Murder on the Orient Express Book (crossover)
        new ItemContributor { Id = 41, ItemId = 24, ContributorId = 26, ContributorType = ContributorType.Author },
        // It Book
        new ItemContributor { Id = 42, ItemId = 25, ContributorId = 21, ContributorType = ContributorType.Author },
        // The Hobbit Book (Tolkien crossover)
        new ItemContributor { Id = 43, ItemId = 26, ContributorId = 5, ContributorType = ContributorType.Author },
        // 1984
        new ItemContributor { Id = 44, ItemId = 27, ContributorId = 13, ContributorType = ContributorType.Author }, // Hypothetical
        // To Kill a Mockingbird
        new ItemContributor { Id = 45, ItemId = 28, ContributorId = 26, ContributorType = ContributorType.Author }, // Hypothetical
        // The Great Gatsby
        new ItemContributor { Id = 46, ItemId = 29, ContributorId = 5, ContributorType = ContributorType.Author }, // Hypothetical
        // Pride and Prejudice
        new ItemContributor { Id = 47, ItemId = 30, ContributorId = 17, ContributorType = ContributorType.Author }, // Hypothetical
        // The Catcher in the Rye
        new ItemContributor { Id = 48, ItemId = 31, ContributorId = 21, ContributorType = ContributorType.Author }, // Hypothetical
        // Brave New World
        new ItemContributor { Id = 49, ItemId = 32, ContributorId = 13, ContributorType = ContributorType.Author }, // Hypothetical
        // The Da Vinci Code
        new ItemContributor { Id = 50, ItemId = 33, ContributorId = 26, ContributorType = ContributorType.Author }, // Hypothetical
        // Gone Girl
        new ItemContributor { Id = 51, ItemId = 34, ContributorId = 21, ContributorType = ContributorType.Author }, // Hypothetical
        // The Hunger Games
        new ItemContributor { Id = 52, ItemId = 35, ContributorId = 17, ContributorType = ContributorType.Author }, // Hypothetical
        // Games
        // World of Warcraft
        new ItemContributor { Id = 53, ItemId = 36, ContributorId = 20, ContributorType = ContributorType.Developer },
        // GTA V
        new ItemContributor { Id = 54, ItemId = 37, ContributorId = 25, ContributorType = ContributorType.Developer },
        // Zelda
        new ItemContributor { Id = 55, ItemId = 38, ContributorId = 20, ContributorType = ContributorType.Publisher }, // Hypothetical
        // Minecraft
        new ItemContributor { Id = 56, ItemId = 39, ContributorId = 6, ContributorType = ContributorType.Developer }, // Hypothetical
        // Fortnite
        new ItemContributor { Id = 57, ItemId = 40, ContributorId = 25, ContributorType = ContributorType.Developer }, // Hypothetical
        // The Witcher 3
        new ItemContributor { Id = 58, ItemId = 41, ContributorId = 20, ContributorType = ContributorType.Developer },
        // Overwatch
        new ItemContributor { Id = 59, ItemId = 42, ContributorId = 20, ContributorType = ContributorType.Developer },
        // Cyberpunk 2077
        new ItemContributor { Id = 60, ItemId = 43, ContributorId = 25, ContributorType = ContributorType.Developer }, // Hypothetical
        // Assassin's Creed
        new ItemContributor { Id = 61, ItemId = 44, ContributorId = 6, ContributorType = ContributorType.Publisher }, // Hypothetical
        // Super Mario
        new ItemContributor { Id = 62, ItemId = 45, ContributorId = 20, ContributorType = ContributorType.Developer }, // Hypothetical
        // Toys/Collectables
        // Funko Pop Batman
        new ItemContributor { Id = 63, ItemId = 46, ContributorId = 24, ContributorType = ContributorType.Manufacturer },
        // Harry Potter Wand
        new ItemContributor { Id = 64, ItemId = 47, ContributorId = 7, ContributorType = ContributorType.Manufacturer }, // Hallmark crossover
        // Star Wars Lightsaber
        new ItemContributor { Id = 65, ItemId = 48, ContributorId = 24, ContributorType = ContributorType.Manufacturer },
        // LotR Ring
        new ItemContributor { Id = 66, ItemId = 49, ContributorId = 7, ContributorType = ContributorType.Manufacturer },
        // Dune Sandworm
        new ItemContributor { Id = 67, ItemId = 50, ContributorId = 24, ContributorType = ContributorType.Manufacturer }
    };

    // For ItemGenres many-to-many, you must use anonymous/Dictionary types in HasData,
    // so keep this as a static array of anonymous objects (as dynamic or Dictionary<string,object>)
    public static object[] ItemGenres = new object[]
    {
        // Existing
        new { ItemId = 1, GenreId = 1 }, // Star Wars: Science Fiction
        new { ItemId = 1, GenreId = 8 }, // Action

        new { ItemId = 2, GenreId = 2 }, // LotR: Fantasy
        new { ItemId = 2, GenreId = 3 }, // Adventure
        new { ItemId = 2, GenreId = 4 }, // Classic

        new { ItemId = 3, GenreId = 8 }, // World of Tanks: Action

        new { ItemId = 4, GenreId = 11 }, // Star Trek Ornament: Collectible

        new { ItemId = 5, GenreId = 8 }, // Batman Begins: Action
        new { ItemId = 5, GenreId = 9 }, // Drama
        new { ItemId = 5, GenreId = 10 }, // Superhero
        // Additional (multiple genres per item for variety, including crossovers)
        new { ItemId = 6, GenreId = 1 }, // Dune Movie: SciFi
        new { ItemId = 6, GenreId = 3 }, // Adventure

        new { ItemId = 7, GenreId = 2 }, // Harry Potter Movie: Fantasy
        new { ItemId = 7, GenreId = 3 }, // Adventure

        new { ItemId = 8, GenreId = 6 }, // The Shining Movie: Horror
        new { ItemId = 8, GenreId = 5 }, // Thriller

        new { ItemId = 9, GenreId = 5 }, // Inception: Thriller
        new { ItemId = 9, GenreId = 1 }, // SciFi

        new { ItemId = 10, GenreId = 8 }, // Dark Knight: Action
        new { ItemId = 10, GenreId = 10 }, // Superhero
        new { ItemId = 10, GenreId = 9 }, // Drama

        new { ItemId = 11, GenreId = 7 }, // Orient Express: Mystery
        new { ItemId = 11, GenreId = 5 }, // Thriller

        new { ItemId = 12, GenreId = 1 }, // Interstellar: SciFi
        new { ItemId = 12, GenreId = 9 }, // Drama

        new { ItemId = 13, GenreId = 1 }, // Matrix: SciFi
        new { ItemId = 13, GenreId = 8 }, // Action

        new { ItemId = 14, GenreId = 3 }, // Jurassic Park: Adventure
        new { ItemId = 14, GenreId = 1 }, // SciFi

        new { ItemId = 15, GenreId = 9 }, // Godfather: Drama
        new { ItemId = 15, GenreId = 4 }, // Classic

        new { ItemId = 16, GenreId = 5 }, // Pulp Fiction: Thriller
        new { ItemId = 16, GenreId = 9 }, // Drama

        new { ItemId = 17, GenreId = 5 }, // Fight Club: Thriller
        new { ItemId = 17, GenreId = 9 }, // Drama

        new { ItemId = 18, GenreId = 9 }, // Forrest Gump: Drama
        new { ItemId = 18, GenreId = 4 }, // Classic

        new { ItemId = 19, GenreId = 9 }, // Shawshank: Drama
        new { ItemId = 19, GenreId = 4 }, // Classic

        new { ItemId = 20, GenreId = 1 }, // Empire Strikes Back: SciFi
        new { ItemId = 20, GenreId = 8 }, // Action

        new { ItemId = 21, GenreId = 1 }, // Dune Book: SciFi
        new { ItemId = 21, GenreId = 3 }, // Adventure
        new { ItemId = 21, GenreId = 4 }, // Classic

        new { ItemId = 22, GenreId = 2 }, // Harry Potter Book: Fantasy
        new { ItemId = 22, GenreId = 3 }, // Adventure

        new { ItemId = 23, GenreId = 6 }, // Shining Book: Horror
        new { ItemId = 23, GenreId = 5 }, // Thriller

        new { ItemId = 24, GenreId = 7 }, // Orient Express Book: Mystery
        new { ItemId = 24, GenreId = 4 }, // Classic

        new { ItemId = 25, GenreId = 6 }, // It: Horror

        new { ItemId = 26, GenreId = 2 }, // Hobbit: Fantasy
        new { ItemId = 26, GenreId = 3 }, // Adventure

        new { ItemId = 27, GenreId = 1 }, // 1984: SciFi (dystopian)
        new { ItemId = 27, GenreId = 4 }, // Classic

        new { ItemId = 28, GenreId = 9 }, // Mockingbird: Drama
        new { ItemId = 28, GenreId = 4 }, // Classic

        new { ItemId = 29, GenreId = 9 }, // Gatsby: Drama
        new { ItemId = 29, GenreId = 4 }, // Classic

        new { ItemId = 30, GenreId = 9 }, // Pride: Drama
        new { ItemId = 30, GenreId = 4 }, // Classic

        new { ItemId = 31, GenreId = 9 }, // Catcher: Drama
        new { ItemId = 31, GenreId = 4 }, // Classic

        new { ItemId = 32, GenreId = 1 }, // Brave New World: SciFi
        new { ItemId = 32, GenreId = 4 }, // Classic

        new { ItemId = 33, GenreId = 5 }, // Da Vinci: Thriller
        new { ItemId = 33, GenreId = 7 }, // Mystery

        new { ItemId = 34, GenreId = 5 }, // Gone Girl: Thriller
        new { ItemId = 34, GenreId = 7 }, // Mystery

        new { ItemId = 35, GenreId = 3 }, // Hunger Games: Adventure
        new { ItemId = 35, GenreId = 1 }, // SciFi

        new { ItemId = 36, GenreId = 2 }, // WoW: Fantasy
        new { ItemId = 36, GenreId = 3 }, // Adventure

        new { ItemId = 37, GenreId = 8 }, // GTA V: Action
        new { ItemId = 37, GenreId = 3 }, // Adventure

        new { ItemId = 38, GenreId = 3 }, // Zelda: Adventure
        new { ItemId = 38, GenreId = 2 }, // Fantasy

        new { ItemId = 39, GenreId = 3 }, // Minecraft: Adventure

        new { ItemId = 40, GenreId = 8 }, // Fortnite: Action

        new { ItemId = 41, GenreId = 2 }, // Witcher: Fantasy
        new { ItemId = 41, GenreId = 3 }, // Adventure

        new { ItemId = 42, GenreId = 8 }, // Overwatch: Action
        new { ItemId = 42, GenreId = 1 }, // SciFi

        new { ItemId = 43, GenreId = 1 }, // Cyberpunk: SciFi
        new { ItemId = 43, GenreId = 8 }, // Action

        new { ItemId = 44, GenreId = 8 }, // Assassin's Creed: Action
        new { ItemId = 44, GenreId = 3 }, // Adventure

        new { ItemId = 45, GenreId = 3 }, // Mario: Adventure

        new { ItemId = 46, GenreId = 11 }, // Funko Batman: Collectible
        new { ItemId = 46, GenreId = 10 }, // Superhero

        new { ItemId = 47, GenreId = 11 }, // HP Wand: Collectible
        new { ItemId = 47, GenreId = 2 }, // Fantasy

        new { ItemId = 48, GenreId = 11 }, // SW Lightsaber: Collectible
        new { ItemId = 48, GenreId = 1 }, // SciFi

        new { ItemId = 49, GenreId = 11 }, // LotR Ring: Collectible
        new { ItemId = 49, GenreId = 2 }, // Fantasy

        new { ItemId = 50, GenreId = 11 }, // Dune Sandworm: Collectible
        new { ItemId = 50, GenreId = 1 } // SciFi
    };
}