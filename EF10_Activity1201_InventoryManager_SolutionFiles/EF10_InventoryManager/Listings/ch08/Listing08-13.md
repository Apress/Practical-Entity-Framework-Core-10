# Listing 8-13: The query generated when using the view to add filtering

Use the view for filtering, and you get a much better query with potentially better performance.

## The code

The SQL Server Profiler shows the query is much less verbose when using the view.

```sql
exec sp_executesql N'SELECT [v].[CategoryName], [v].[Contributors], [v].[Genres], [v].[ItemId], [v].[ItemName], [v].[TotalValue]
FROM [vwItemsWithGenresAndContributors] AS [v]
WHERE [v].[ItemName] LIKE @filter OR [v].[Contributors] LIKE @filter',N'@filter nvarchar(4000)',@filter=N'%LorD%'
```  