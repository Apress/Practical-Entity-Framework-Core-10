# Listing 8-11. The query that is generated from the filter activity [Activity 8-1, Task 2, Step 1 & 2]

Creating the filter query generates a very large query that does work well to get the data.

## Code

```sql
exec sp_executesql N'SELECT [i].[Id], [i].[CategoryId], [i].[CreatedByUserId], [i].[CreatedDate], [i].[CurrentValue], [i].[Description], [i].[IsActive], [i].[IsOnSale], [i].[LastModifiedDate], [i].[LastModifiedUserId], [i].[Name], [i].[Notes], [i].[PurchasePrice], [i].[PurchasedDate], [i].[Quantity], [i].[SoldDate], [s].[Id], [s].[ContributorId], [s].[ContributorType], [s].[ItemId], [s].[Id0], [s].[ContributorName], [s].[Description], [s].[IsActive]
FROM [Items] AS [i]
LEFT JOIN (
    SELECT [i1].[Id], [i1].[ContributorId], [i1].[ContributorType], [i1].[ItemId], [c0].[Id] AS [Id0], [c0].[ContributorName], [c0].[Description], [c0].[IsActive]
    FROM [ItemContributors] AS [i1]
    INNER JOIN [Contributors] AS [c0] ON [i1].[ContributorId] = [c0].[Id]
) AS [s] ON [i].[Id] = [s].[ItemId]
WHERE [i].[Name] LIKE @filter OR EXISTS (
    SELECT 1
    FROM [ItemContributors] AS [i0]
    INNER JOIN [Contributors] AS [c] ON [i0].[ContributorId] = [c].[Id]
    WHERE [i].[Id] = [i0].[ItemId] AND [c].[ContributorName] LIKE @userInput)
ORDER BY [i].[Id], [s].[Id]',N'@filter nvarchar(100),@userInput nvarchar(100)',@filter=N'%LorD%',@userInput=N'LorD'
```  