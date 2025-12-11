# Listing 7-25. The Up method of the migration

Craete the new function using the migration and a call to the flat script file.

## The code

```cs
migrationBuilder.SqlResource("EF10_InventoryDBLibrary.Migrations.Scripts.Functions.ItemsWithCsvDetails.fnItemsWithCsvDetails_v0.sql");
```  
