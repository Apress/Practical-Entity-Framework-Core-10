# Listing 10-15: The migration to update the data as encrypted to the PII column

Create a new migration named `restore-piinumber-encrypted` and place the command below to run the script in the `Up` method.

## The Migration

Place the following code in the `UP` command of the new `restore-piinumber-encrypted` migration.

```cs
migrationBuilder.SqlResource("EF10_InventoryDBLibrary.Migrations.Scripts.Operations.RestorePIINumberEncrypted.sql");
```  