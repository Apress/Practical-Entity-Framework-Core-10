# Listing 8-6: An inefficient IEnumerable first query [Exercise 8-1, Task 1, Step 1]

This first method makes the common mistake of converting the object to an IEnumerable right away, which means all additional processing happens on the client side.

## The code

Add the following code to the `SortingFilteringPagingMenu.cs` file in the method `ListItemsThenOrderAndTake`

```cs
//Get all the items first, ten order them, then take the first 25
//This is not efficient, but it demonstrates the concept of ordering after getting a list
var items = await _db.Items.ToListAsync();      //IEnumerable<Item>, so no ordering yet, moved to client-side
items = items.OrderByDescending(x => x.Name)    //IOrderedEnumerable<Item>, so still client-side
                .Take(25)                       //IEnumerable<Item>, so still client-side
                .ToList();                      //Make it to a list again.
return items;
```  