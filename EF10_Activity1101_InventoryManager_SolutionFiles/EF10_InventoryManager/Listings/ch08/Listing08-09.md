# Listing 8-9: The result of the second query as shown in Exercise 8-1, Task 1, Step 4

The second query performs everything on the server-side, only returning 25 rows (the take value) and returing the rows in order, pre-sorted. No work needs to be done on the client side at all.

## The code

The query as captured by the SQL Server Profiler is below: 

```sql
exec sp_executesql N'SELECT TOP(@p) [i].[Id], [i].[CategoryId], [i].[CreatedByUserId], [i].[CreatedDate], [i].[CurrentValue], [i].[Description], [i].[IsActive], [i].[IsOnSale], [i].[LastModifiedDate], [i].[LastModifiedUserId], [i].[Name], [i].[Notes], [i].[PurchasePrice], [i].[PurchasedDate], [i].[Quantity], [i].[SoldDate]
FROM [Items] AS [i]
ORDER BY [i].[Name] DESC',N'@p int',@p=25
```  