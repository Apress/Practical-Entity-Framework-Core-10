# Listing 7-33: Reference the file to create the ItemsWithGenresAndContributors view.

Add the code to the Up method of the new migration.

## Code

Place this code in the Up method of the `create-vwItemsWithGenresAndContributors` migration

```cs
migrationBuilder.SqlResource("EF10_InventoryDBLibrary.Migrations.Scripts.Views.ItemsWithGenresAndContributors.vwItemsWithGenresAndContributors_v0.sql");
```  