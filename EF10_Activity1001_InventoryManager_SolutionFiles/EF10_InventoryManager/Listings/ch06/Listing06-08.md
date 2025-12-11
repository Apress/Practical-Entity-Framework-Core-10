# Listing 6-8: Generated T-SQL

The use of Include allows EF to build a join in the query as shown below. 

## SQL Query

The SQL query to get all items with categories follows.

```sql
SELECT [i].[Id], [i].[CategoryId], [i].[CreatedByUserId], [i].[CreatedDate], [i].[CurrentValue], [i].[Description], [i].[IsActive], [i].[IsOnSale], [i].[LastModifiedDate], [i].[LastModifiedUserId], [i].[Name], [i].[Notes], [i].[PurchasePrice], [i].[PurchasedDate], [i].[Quantity], [i].[SoldDate], [c].[Id], [c].[CategoryName], [c].[Description], [c].[IsActive]
FROM [Items] AS [i]
INNER JOIN [Categories] AS [c] ON [i].[CategoryId] = [c].[Id]
```

>**NOTE:** Don't try to put this anywhere in your code, it's for learning purposes only.

## Conclusion

This T-SQL query shows that the use of Include causes the framework to produce a query that contains a join.