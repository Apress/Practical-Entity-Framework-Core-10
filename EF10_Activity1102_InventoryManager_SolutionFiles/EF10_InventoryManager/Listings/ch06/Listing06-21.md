# Listing 6-21: Get the Item - Category - Genre information

Use the T-SQL command to get the new Item, associated category, and genre details for `Blade Runner 2049`

## The Query

Run the following query in SSMS to see the results.

```sql
SELECT i.[Name], c.CategoryName, g.GenreName
FROM Items i 
INNER JOIN Categories c on i.CategoryId = c.Id
INNER JOIN ItemGenres ig on i.Id = ig.ItemId
INNER JOIN Genres g on ig.GenreId = g.Id
WHERE i.[Name] = 'Blade Runner 2049'
```  