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
        new Contributor { Id = 12, ContributorName = "James Newton Howard" }
    };

    public static Item[] Items = new[]
    {
        new Item { Id = 1, Name = "Star Wars: A New Hope", Quantity = 1, CategoryId = 1, Description = "The original Star Wars movie.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 2, Name = "The Lord of the Rings: The Fellowship of the Ring", Quantity = 1, CategoryId = 2, Description = "Classic fantasy novel by J.R.R. Tolkien.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 3, Name = "World of Tanks", Quantity = 1, CategoryId = 3, Description = "Popular online multiplayer tank game.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 4, Name = "Star Trek: U.S.S. Enterprise: NCC-1701 Ornament", Quantity = 1, CategoryId = 4, Description = "Collectible Hallmark ornament.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate },
        new Item { Id = 5, Name = "Batman Begins", Quantity = 1, CategoryId = 1, Description = "Christopher Nolan's Batman movie.", CreatedByUserId = _systemUserId, CreatedDate = _seedItemCreatedDate }
    };

    public static ItemContributor[] ItemContributors = new[]
    {
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
        new ItemContributor { Id = 12, ItemId = 5, ContributorId = 12, ContributorType = ContributorType.Composer }
    };

    // For ItemGenres many-to-many, you must use anonymous/Dictionary types in HasData,
    // so keep this as a static array of anonymous objects (as dynamic or Dictionary<string,object>)
    public static object[] ItemGenres = new object[]
    {
        new { ItemId = 1, GenreId = 1 }, // Star Wars: Science Fiction
        new { ItemId = 1, GenreId = 8 }, // Action

        new { ItemId = 2, GenreId = 2 }, // LotR: Fantasy
        new { ItemId = 2, GenreId = 3 }, // Adventure
        new { ItemId = 2, GenreId = 4 }, // Classic

        new { ItemId = 3, GenreId = 8 }, // World of Tanks: Action

        new { ItemId = 4, GenreId = 11 }, // Star Trek Ornament: Collectible

        new { ItemId = 5, GenreId = 8 }, // Batman Begins: Action
        new { ItemId = 5, GenreId = 9 }, // Drama
        new { ItemId = 5, GenreId = 10 } // Superhero
    };
}
