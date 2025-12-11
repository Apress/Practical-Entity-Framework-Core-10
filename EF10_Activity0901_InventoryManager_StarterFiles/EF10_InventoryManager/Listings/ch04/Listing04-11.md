# Listing 04-11: Updating the database

Use one of the following commands to update the database.

## Create the migration to update for Audited model

To complete this part of the activity, run the following command from the solution level folder in VS Code:

```bash  
dotnet ef database update --project EF10_InventoryDBLibrary --startup-project EF10_InventoryManager
```  

or run this command from the project-level folder in VS Code.

```bash
dotnet ef database update --project EF10_InventoryDBLibrary
```  

## In Visual Studio

Alternatively, you can update the database using the traditional command in Visual Studio

```bash
update-database
``` 