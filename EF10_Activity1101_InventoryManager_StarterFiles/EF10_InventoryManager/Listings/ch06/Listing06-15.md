# Listing 6-15: Query the database to see all item and category information

Using the T-SQL query below, you can see all items that are in your database with their joined Category information

## Implement the Method

Run the T-SQL query below in SQL Server Management Studio (SSMS) to see your data and validate your results.  

```SQL
SELECT i.Id, i.Name, i.Description
		, c.Id, c.CategoryName, c.Description
FROM Items i
INNER JOIN Categories c on i.CategoryId = c.Id
```  