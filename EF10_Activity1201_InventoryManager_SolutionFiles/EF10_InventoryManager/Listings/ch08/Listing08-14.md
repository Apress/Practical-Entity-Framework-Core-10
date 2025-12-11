# Listing 8-14. Using Paging to prevent overwhelming result sets.

Even in today's world, a filter of `a` or `e` could return all of your records, and that could cause you some real problems.  It might also block other customers from using your site well.  For that reason, you might want to put some failsafe in place and only fetch the rows needed for users to make good decisions.  Also, you might do more to block results if too many are returned.

## The Code

Replace the four lines of code called out in the program with the following code to perform paging on the filtered results.

```cs
var pageResults = await _db.ItemDetailSummaries
                    .Where(x => EF.Functions.Like(x.ItemName ?? "", filter)
                                || EF.Functions.Like(x.Contributors ?? "", filter))
                    .OrderBy(i => i.ItemName)
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
```  