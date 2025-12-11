using EF10_InventoryModels;

namespace EF10_InventoryManagerUnitTests;

public static class StaticTestingHelpers
{
    public static List<Contributor> Contributors { get; private set; }
    public static List<Genre> Genres { get; private set; }
    public static List<Category> Categories { get; private set; }
    public static List<Item> Items { get; private set; }
    public static List<ItemContributor> ItemContributors { get; private set; }

    static StaticTestingHelpers()
    {
        Contributors = new List<Contributor>
        {
            new Contributor { Id = 1, ContributorName = "Tom Hanks" },
            new Contributor { Id = 2, ContributorName = "Meryl Streep" },
            new Contributor { Id = 3, ContributorName = "Leonardo DiCaprio" },
            new Contributor { Id = 4, ContributorName = "Scarlett Johansson" },
            new Contributor { Id = 5, ContributorName = "Robert Downey Jr." },
            new Contributor { Id = 6, ContributorName = "Emma Watson" },
            new Contributor { Id = 7, ContributorName = "Chris Hemsworth" },
            new Contributor { Id = 8, ContributorName = "Natalie Portman" },
            new Contributor { Id = 9, ContributorName = "J.K. Rowling" },
            new Contributor { Id = 10, ContributorName = "Stephen King" },
            new Contributor { Id = 11, ContributorName = "Dan Brown" },
            new Contributor { Id = 12, ContributorName = "J.R.R. Tolkien" },
            new Contributor { Id = 13, ContributorName = "George R.R. Martin" },
            new Contributor { Id = 14, ContributorName = "Agatha Christie" },
            new Contributor { Id = 15, ContributorName = "Terry Pratchett" }
        };

        Genres = new List<Genre>
        {
            new Genre { Id = 1, GenreName = "Sci-Fi" },
            new Genre { Id = 2, GenreName = "Horror" },
            new Genre { Id = 3, GenreName = "Thriller" },
            new Genre { Id = 4, GenreName = "Fantasy" },
            new Genre { Id = 5, GenreName = "Comedy" }
        };

        Categories = new List<Category>
        {
            new Category { Id = 1, CategoryName = "Movie" },
            new Category { Id = 2, CategoryName = "Book" }
        };

        Items = new List<Item>
        {
            new Item { Id = 1, Name = "Inception", CategoryId = 1 },
            new Item { Id = 2, Name = "The Shining", CategoryId = 1 },
            new Item { Id = 3, Name = "The Da Vinci Code", CategoryId = 1 },
            new Item { Id = 4, Name = "The Lord of the Rings: The Fellowship of the Ring", CategoryId = 1 },
            new Item { Id = 5, Name = "Avengers: Endgame", CategoryId = 1 },
            new Item { Id = 6, Name = "Black Swan", CategoryId = 1 },
            new Item { Id = 7, Name = "Thor: Ragnarok", CategoryId = 1 },
            new Item { Id = 8, Name = "Forrest Gump", CategoryId = 1 },
            new Item { Id = 9, Name = "The Devil Wears Prada", CategoryId = 1 },
            new Item { Id = 10, Name = "Iron Man", CategoryId = 1 },
            new Item { Id = 11, Name = "Harry Potter and the Sorcerer's Stone", CategoryId = 2 },
            new Item { Id = 12, Name = "It", CategoryId = 2 },
            new Item { Id = 13, Name = "The Da Vinci Code", CategoryId = 2 },
            new Item { Id = 14, Name = "The Hobbit", CategoryId = 2 },
            new Item { Id = 15, Name = "A Game of Thrones", CategoryId = 2 },
            new Item { Id = 16, Name = "Murder on the Orient Express", CategoryId = 2 },
            new Item { Id = 17, Name = "Good Omens", CategoryId = 2 },
            new Item { Id = 18, Name = "The Stand", CategoryId = 2 },
            new Item { Id = 19, Name = "Angels & Demons", CategoryId = 2 },
            new Item { Id = 20, Name = "The Colour of Magic", CategoryId = 2 }
        };

        ItemContributors = new List<ItemContributor>
        {
            new ItemContributor { ItemId = 1, ContributorId = 3 },
            new ItemContributor { ItemId = 2, ContributorId = 2 },
            new ItemContributor { ItemId = 2, ContributorId = 4 },
            new ItemContributor { ItemId = 3, ContributorId = 1 },
            new ItemContributor { ItemId = 4, ContributorId = 6 },
            new ItemContributor { ItemId = 4, ContributorId = 8 },
            new ItemContributor { ItemId = 5, ContributorId = 5 },
            new ItemContributor { ItemId = 5, ContributorId = 7 },
            new ItemContributor { ItemId = 5, ContributorId = 4 },
            new ItemContributor { ItemId = 6, ContributorId = 8 },
            new ItemContributor { ItemId = 7, ContributorId = 7 },
            new ItemContributor { ItemId = 7, ContributorId = 1 },
            new ItemContributor { ItemId = 8, ContributorId = 1 },
            new ItemContributor { ItemId = 9, ContributorId = 2 },
            new ItemContributor { ItemId = 9, ContributorId = 6 },
            new ItemContributor { ItemId = 10, ContributorId = 5 },
            new ItemContributor { ItemId = 11, ContributorId = 9 },
            new ItemContributor { ItemId = 12, ContributorId = 10 },
            new ItemContributor { ItemId = 13, ContributorId = 11 },
            new ItemContributor { ItemId = 14, ContributorId = 12 },
            new ItemContributor { ItemId = 15, ContributorId = 13 },
            new ItemContributor { ItemId = 16, ContributorId = 14 },
            new ItemContributor { ItemId = 17, ContributorId = 15 },
            new ItemContributor { ItemId = 18, ContributorId = 10 },
            new ItemContributor { ItemId = 19, ContributorId = 11 },
            new ItemContributor { ItemId = 20, ContributorId = 15 }
        };

        // Assign navigation properties
        // Categories to Items and Items to Categories (assuming Category has virtual List<Item> Items)
        foreach (var item in Items)
        {
            item.Category = Categories.First(c => c.Id == item.CategoryId);
        }
        foreach (var category in Categories)
        {
            category.Items = Items.Where(i => i.CategoryId == category.Id).ToList();
        }

        // Genres to Items
        Items[0].Genres = new List<Genre> { Genres[0], Genres[2] }; // Inception: Sci-Fi, Thriller
        Items[1].Genres = new List<Genre> { Genres[1] }; // The Shining: Horror
        Items[2].Genres = new List<Genre> { Genres[2] }; // Da Vinci Code: Thriller
        Items[3].Genres = new List<Genre> { Genres[3] }; // LOTR: Fantasy
        Items[4].Genres = new List<Genre> { Genres[0], Genres[4] }; // Avengers: Sci-Fi, Comedy
        Items[5].Genres = new List<Genre> { Genres[2], Genres[1] }; // Black Swan: Thriller, Horror
        Items[6].Genres = new List<Genre> { Genres[4], Genres[0] }; // Thor Ragnarok: Comedy, Sci-Fi
        Items[7].Genres = new List<Genre> { Genres[4] }; // Forrest Gump: Comedy
        Items[8].Genres = new List<Genre> { Genres[4] }; // Devil Wears Prada: Comedy
        Items[9].Genres = new List<Genre> { Genres[0], Genres[4] }; // Iron Man: Sci-Fi, Comedy
        Items[10].Genres = new List<Genre> { Genres[3] }; // Harry Potter: Fantasy
        Items[11].Genres = new List<Genre> { Genres[1] }; // It: Horror
        Items[12].Genres = new List<Genre> { Genres[2] }; // Da Vinci Code: Thriller
        Items[13].Genres = new List<Genre> { Genres[3] }; // The Hobbit: Fantasy
        Items[14].Genres = new List<Genre> { Genres[3], Genres[2] }; // Game of Thrones: Fantasy, Thriller
        Items[15].Genres = new List<Genre> { Genres[2] }; // Murder Orient: Thriller
        Items[16].Genres = new List<Genre> { Genres[3], Genres[4] }; // Good Omens: Fantasy, Comedy
        Items[17].Genres = new List<Genre> { Genres[1], Genres[0] }; // The Stand: Horror, Sci-Fi
        Items[18].Genres = new List<Genre> { Genres[2] }; // Angels & Demons: Thriller
        Items[19].Genres = new List<Genre> { Genres[3], Genres[4] }; // Colour of Magic: Fantasy, Comedy

        // Items to Genres
        foreach (var genre in Genres)
        {
            genre.Items = new List<Item>();
        }
        foreach (var item in Items)
        {
            if (item.Genres != null)
            {
                foreach (var genre in item.Genres)
                {
                    genre.Items.Add(item);
                }
            }
        }

        // ItemContributors to Items (assuming Contributor has virtual List<ItemContributor> ItemContributors)
        foreach (var item in Items)
        {
            item.ItemContributors = ItemContributors.Where(ic => ic.ItemId == item.Id).ToList();
        }
        foreach (var contributor in Contributors)
        {
            contributor.ItemContributors = ItemContributors.Where(ic => ic.ContributorId == contributor.Id).ToList();
        }
    }
}
