# Listing 7-26. The Down method of the migration

Make sure the `fnItemsWithCsvDetails` is removed on rollback.

## The code

```cs
migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS dbo.fnItemsWithCsvDetails");  
```  