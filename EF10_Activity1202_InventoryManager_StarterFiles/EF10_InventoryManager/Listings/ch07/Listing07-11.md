# Listing 7-11: The command to add to the Up method of the new migration

In the migration, leverage the scripting strategy to create a mapping to the new file you just created (Listing 7-6) under the `EF10_InventoryDBLibrary/Migrations/Scripts/Procedures/GetItemsByGenre` folder.

## The code

```cs
migrationBuilder.SqlResource("EF10_InventoryDBLibrary.Migrations.Scripts.Procedures.GetItemsByGenre.GetItemsByGenre_v0.sql");
```  