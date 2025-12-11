# Listing 14-9 - Bulk Update with ExecuteUpdate

Perform a bulk update using the new ExecuteUpdate method.

## Code Example

The following example sets the IsOnSale property to true for all items in the "Movie" category.

```csharp

// Set all Items with category "Movie" as IsOnSale = true
var countMovies = await _db.Items
                    .Where(m => m.Category.CategoryName == "Movie")
                    .ExecuteUpdateAsync(s => 
                        s.SetProperty(i => i.IsOnSale, i => true)
                    );
```