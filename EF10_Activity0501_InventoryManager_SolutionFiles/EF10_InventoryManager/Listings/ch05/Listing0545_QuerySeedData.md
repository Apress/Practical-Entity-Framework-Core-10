# Listing 5-45: Query the data

Use this query to prove the data is seeded successfully

## The Query

```sql
SELECT 
    i.Id AS ItemId,
    i.Name AS ItemName,
    c.CategoryName,
    -- Comma-separated list of genres
    STUFF((
        SELECT ', ' + g.GenreName
        FROM ItemGenres ig
        INNER JOIN Genres g ON g.Id = ig.GenreId
        WHERE ig.ItemId = i.Id
        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS Genres,
    -- Comma-separated list of contributors
    STUFF((
        SELECT ', ' + co.ContributorName
        FROM ItemContributors ic
        INNER JOIN Contributors co ON co.Id = ic.ContributorId
        WHERE ic.ItemId = i.Id
        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS Contributors
FROM Items i
INNER JOIN Categories c ON i.CategoryId = c.Id
ORDER BY i.Id;
```  