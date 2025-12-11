# Listing 14-30: Get all Media Items (Books and Movies)

Get the MediaItems (Books and Movies)

## The code

The code to get all the MediaItems (Books and Movies)

```cs
var books = await _db.Books
    .AsNoTracking()
    .Select(b => new
    {
        b.Id,
        b.ItemName,
        b.PlotSummary,
        CategoryName = b.Category.CategoryName,
        Type = "Book"
    }).ToListAsync();

var movies = await _db.Movies
    .AsNoTracking()
    .Select(m => new
    {
        m.Id,
        m.ItemName,
        m.PlotSummary,
        CategoryName = m.Category.CategoryName,
        Type = "Movie"
    }).ToListAsync();

var mediaItems = books.Concat(movies).ToList();
```  
>**Note:** The MediaItem type is not able to be queried directly.