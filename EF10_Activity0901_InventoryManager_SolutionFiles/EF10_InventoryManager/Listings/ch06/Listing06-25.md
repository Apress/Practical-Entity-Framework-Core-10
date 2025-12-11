# Listing 6-25: Get the Item - Sale Status

Use the T-SQL command to get Item and Sale Status information

## The Query

Run the following query in SSMS to see the results.

```sql
SELECT i.[Name], i.IsOnSale
FROM Items i
```  