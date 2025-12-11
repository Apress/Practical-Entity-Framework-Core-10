# Listing 10-7: The command to add to the migration

Add this in the migration

## The Command for the migration

Add this to the UP command of the `EncryptionMigration_CertsAndKeysGeneration` migration.

```cs
migrationBuilder.SqlResource("EF10_InventoryDBLibrary.Migrations.Scripts.Operations.GenerateCertsAndKeys.sql");
```  