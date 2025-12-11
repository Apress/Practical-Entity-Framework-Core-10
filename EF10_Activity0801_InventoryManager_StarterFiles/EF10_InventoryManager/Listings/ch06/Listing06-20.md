# Listing 6-20: A helper method to create a genre and a movie in the genre

A quick helper that lets you create a new genre and a movie in that genre for learning about updating

## The code

The code is already in the project, but here is the listing just by itself for review.

```cs
private async Task CreateAMovieWithGenre()
{
    Console.WriteLine(new string('*', 60));
    Console.WriteLine("Creating a new movie with genre...");

    var existingItem = await _db.Items
        .Where(i => i.Name == "Blade Runner 2049")
        .SingleOrDefaultAsync();
    if (existingItem != null)
    {
        Console.WriteLine($"Movie 'Blade Runner 2049' already exists with ID: {existingItem.Id}");
        return; // Exit if the movie already exists
    }

    // Create a new genre if it doesn't exist
    var genre = await _db.Genres.ToListAsync();
    var categories = await _db.Categories.ToListAsync();
    var movieCategory = categories.FirstOrDefault(c => c.CategoryName == "Movie") ??
                        new Category { CategoryName = "Movie", Description = "A category for movies." };
    var genreSciFi = genre.FirstOrDefault(g => g.GenreName == "Science Fiction") ??
                        new Genre { GenreName = "Science Fiction", IsActive = true };
    //Dystopian genre should not exist.
    var genreDystopian = genre.FirstOrDefault(g => g.GenreName == "Dystopian") ??
                        new Genre { GenreName = "Dystopian", IsActive = true };
    // Create a new movie item
    var movie = new Item
    {
        Name = "Blade Runner 2049",
        Description = "A sequel to the original Blade Runner.",
        CategoryId = movieCategory.Id,
        Category = movieCategory, // Associate the category
        IsActive = true,
        IsOnSale = false,
        Genres = new List<Genre> { genreSciFi, genreDystopian }, // Associate the genres
        CreatedByUserId = Guid.NewGuid().ToString(),
        CreatedDate = DateTime.UtcNow,
    };

    _db.Items.Add(movie);
    await _db.SaveChangesAsync();

    Console.WriteLine($"Blade runner 2049 created with ID: {movie.Id}");
    Console.WriteLine(new string('*', 60));
    return true; // Indicate success
}
```  