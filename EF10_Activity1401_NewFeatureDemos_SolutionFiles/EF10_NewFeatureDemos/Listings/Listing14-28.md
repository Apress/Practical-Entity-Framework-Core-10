# Listing 14-28: Get all the Books from the TPC hierarchy

Show the Books

## The code

This query runs and pulls only the records in the Books table

```cs
var books = await _db.Books
    .AsNoTracking()
    .Select(b => new
    {
        b.Id,
        b.ItemName,
        b.PlotSummary,
        b.ISBN,
        CategoryName = b.Category.CategoryName
    }).ToListAsync();
```  