# Listing 8-12: Using the view to get details

Using the view has the benefit of having the query plan in place for the join and generates a much less verbose query overall.  

Another added benefit is the result set contains the contributor details in a fashion that is easy to leverage from the UI.

## The code

Replace the line `//TODO: Replace this line with code from Listing 8-12` in the method `FilterItemsByUserInputUsingView` with this code to leverage the view for filtering

```cs
var filter = $"%{userInput}%";
var items = await _db.ItemDetailSummaries
                        .Where(x => EF.Functions.Like(x.ItemName ?? "", filter)
                                    || EF.Functions.Like(x.Contributors ?? "", filter))
                        .ToListAsync();
return items;
```  