# Listing 8-10: Filter results by user input [Exercise 8-1, Task 2, Step 1]

Use a query to filter where the Item name "Contains" the search term. Do not convert to list until after the query is formed.

## The code

Add the following code to the `SortingFilteringPagingMenu.cs` file in the method `FilterItemsByUserInput`

```cs
//Filter items by user input, case insensitive, and return as a list
var filter = $"%{userInput}%";
var items = await _db.Items.Include(i => i.ItemContributors)
                            .ThenInclude(ic => ic.Contributor)        
                .Where(i => EF.Functions.Like(i.Name ?? "", filter)
                    || i.ItemContributors.Any(ic =>
                        ic.Contributor != null &&
                        EF.Functions.Like(ic.Contributor.ContributorName ?? "", userInput)))
                .ToListAsync();
```  