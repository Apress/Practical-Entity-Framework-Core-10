# Listing 6-24: Update Multiple Items: Set IsOnSale == True

Toggle all items to be `on sale` using `UpdateRange`.

## The code

Leverage this code to complete the `UpdateMultipleItemsOnSale` method.

```cs
public async Task<bool> UpdateMultipleItemsOnSale()
{
    var items = await _db.Items
                            .ToListAsync();
    if (!items.Any())
    {
        Console.WriteLine("No items to update.");
        return false; //indicate failure
    }
    foreach (var item in items)
    {
        item.IsOnSale = true; //set all items to on sale
    }
    _db.Items.UpdateRange(items);
    var result = await _db.SaveChangesAsync();
    return result == items.Count; //return true if all items were updated
}
```