# Listing 7-29. Queries to test the new view

Use these queries to test the output of the new view

## The queries

```sql
SELECT * FROM vwItemsWithGenresAndContributors
GO

SELECT * FROM vwItemsWithGenresAndContributors
WHERE Genres like '%Action%'
GO

SELECT * FROM vwItemsWithGenresAndContributors
WHERE Genres like '%Action%'
ORDER BY TotalValue DESC
GO
```