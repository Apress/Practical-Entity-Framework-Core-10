# Listing 8-7: An Better operation - IQueryable as long as possible. [Exercise 8-1, Task 1, Step 2]

This second method improves on the first method because it keeps all of the sorting and limiting code on the server-side, effectively keeping the processing out of the client side of the application.

## The code

Add the following code to the `SOrtingFilteringPagingMenu.cs` file in the method `OrderItemsThenTakeAndList`

```cs
//Order the items, limit to 25, then convert to a list
//This is more efficient as it uses the database to do the ordering and limiting
var items = await _db.Items.OrderByDescending(x => x.Name)     //IOrderedQueryable<Item>
                        .Take(25)                              //IQueryable<Item>, so no ToList() yet, still server-side
                        .ToListAsync();                        //now IEnumerable<Item>
return items;
```  