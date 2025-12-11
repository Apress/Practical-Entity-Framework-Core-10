# Listing 14-29: Get all the Movies from the TPC hierarchy

Show the Movies

## The code

This query runs and pulls only the records in the Movies table

```cs
var movies = await _db.Movies
    .AsNoTracking()
    .Select(m => new
    {
        m.Id,
        m.ItemName,
        m.PlotSummary,
        m.MPAARating,
        CategoryName = m.Category.CategoryName
    }).ToListAsync();

```  