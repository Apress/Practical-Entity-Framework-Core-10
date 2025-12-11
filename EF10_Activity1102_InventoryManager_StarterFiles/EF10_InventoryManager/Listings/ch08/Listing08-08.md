# Listing 8-8: The result of the first query as shown in Exercise 8-1, Task 1, Step 4

The first query doesn't filter or sort, and returns all 50 rows to the client.

## The code

The query as captured by the SQL Server Profiler is below: 

```sql
SELECT [i].[Id], [i].[CategoryId], [i].[CreatedByUserId], [i].[CreatedDate], [i].[CurrentValue], [i].[Description], [i].[IsActive], [i].[IsOnSale], [i].[LastModifiedDate], [i].[LastModifiedUserId], [i].[Name], [i].[Notes], [i].[PurchasePrice], [i].[PurchasedDate], [i].[Quantity], [i].[SoldDate]
FROM [Items] AS [i]
```  