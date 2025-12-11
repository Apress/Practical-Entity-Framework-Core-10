# Listing 6-6: Use LINQ to get data with a filter

The ability to get a subset of the data using a filter with a LINQ statement

>**Note:** This is how you will typically do filters in the real world.

## The Method Declaration

Retrieve Items from the database based on a passed-in filter using LINQ.

1. The final method code follows:


```cs
private async Task<List<Item>> GetAllItemsByFilterAsync_LINQ(string filter)
{
    return await _db.Items
                    .Where(x => string.IsNullOrWhiteSpace(filter)
                                || x.Name.Contains(filter))
                    .OrderBy(x => x.Name)
                    .ToListAsync();
}
```  

## Conclusion

This concludes Listing 6-6.