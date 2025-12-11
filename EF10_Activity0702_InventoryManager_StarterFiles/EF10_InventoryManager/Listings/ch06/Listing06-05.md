# Listing 6-5: Use the AsyncEnumerable to get Data for Enumeration

The ability to get a subset of the data with a filter using the AsyncEnumerator.

>**Note:** You will likely not use this approach in the real world.

## The Method Declaration

Retrieve Items from the database based on a passed-in filter.

1. The final method code follows:

    ```cs
    public async Task<List<Item>> GetAllItemsByFilterAsyncEnumerable(string filter)
    {
        var query = _db.Items.AsQueryable();
        if (!string.IsNullOrWhiteSpace(filter))
        {
            query = query.Where(x => x.Name.Contains(filter));
        }
        var enumerator = query
            .AsAsyncEnumerable()
            .GetAsyncEnumerator();
        var items = new List<Item>();
        try
        {
            while (await enumerator.MoveNextAsync())
            {
                items.Add(enumerator.Current);
            }
        }
        finally
        {
            await enumerator.DisposeAsync();
        }
        return items;
    }
    ```  

## Conclusion

This concludes listing 6-5.