# Listing 14-24: The ability to get items by a list of genre names

The ability to get data with parameters is one of the performance enhancements for LINQ

## The code

The code is the same as would have been run in previous versions of EF

```cs
var genreNames = new List<string> { "Sci-Fi", "Fantasy" };

// Query: get all items that have at least one of the selected genres
var genres = new List<string> { "Sci-Fi", "Fantasy", };
var itemsByGenres = _db.Items
    .Include(i => i.Genres) 
    .Where(i => i.Genres.Any(g => genres.Contains(g.GenreName)));
```  

However, in the past, this would have generated T-SQL similar to

```sql
WHERE EXISTS (
    SELECT 1
    FROM [ItemGenres] AS [g]
    WHERE [i].[Id] = [g].[ItemId]
      AND ([g].[GenreName] = N'Sci-Fi' OR [g].[GenreName] = N'Fantasy')
)
```  
>**Note:** Notice the use of string literals, which won't be saved in the query plan

And now it will generate T-SQL like this:

```sql
exec sp_executesql N'SELECT [i].[Id], [i].[CategoryId], [i].[Description], [i].[IsActive], [i].[IsDeleted], [i].[IsOnSale], [i].[ItemName], [i].[TenantId], [s].[ItemId], [s].[GenreId], [s].[Id], [s].[GenreName], [s].[IsActive], [s].[IsDeleted]
FROM [Items] AS [i]
LEFT JOIN (
    SELECT [i1].[ItemId], [i1].[GenreId], [g2].[Id], [g2].[GenreName], [g2].[IsActive], [g2].[IsDeleted]
    FROM [ItemGenres] AS [i1]
    INNER JOIN (
        SELECT [g1].[Id], [g1].[GenreName], [g1].[IsActive], [g1].[IsDeleted]
        FROM [Genres] AS [g1]
        WHERE [g1].[IsDeleted] = CAST(0 AS bit) AND [g1].[IsActive] = CAST(1 AS bit)
    ) AS [g2] ON [i1].[GenreId] = [g2].[Id]
) AS [s] ON [i].[Id] = [s].[ItemId]
WHERE [i].[IsDeleted] = CAST(0 AS bit) AND [i].[IsActive] = CAST(1 AS bit) AND [i].[TenantId] = 1 AND EXISTS (
    SELECT 1
    FROM [ItemGenres] AS [i0]
    INNER JOIN (
        SELECT [g].[Id], [g].[GenreName]
        FROM [Genres] AS [g]
        WHERE [g].[IsDeleted] = CAST(0 AS bit) AND [g].[IsActive] = CAST(1 AS bit)
    ) AS [g0] ON [i0].[GenreId] = [g0].[Id]
    WHERE [i].[Id] = [i0].[ItemId] AND [g0].[GenreName] IN (@genres1, @genres2))
ORDER BY [i].[Id], [s].[ItemId], [s].[GenreId]',N'@genres1 nvarchar(50),@genres2 nvarchar(50)',@genres1=N'Sci-Fi',@genres2=N'Fantasy'
```  
>**Note:** Note the use of parameters and the IN clause -> `AND [g0].[GenreName] IN (@genres1, @genres2))`, allowing for reuse of the existing query plan