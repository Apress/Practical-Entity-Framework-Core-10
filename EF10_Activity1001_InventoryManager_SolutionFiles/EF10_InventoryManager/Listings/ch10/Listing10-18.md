# Listing 10-18

Get the `Item` Data before `Always Encrypted` Encryption is applied

## The Query

Use this query in SSMS against the `InventoryManagerDB_1002` to see the data

```sql
SELECT Id, [Name], [Description], PIINumber
FROM Items
ORDER BY [Name] 
```  