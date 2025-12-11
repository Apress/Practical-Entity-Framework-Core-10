# Listing 04-09: Creating a migration

You've likely seen this before, but you can easily create a migration with simple commands.

## Create the migration to update for Audited model

To complete this part of the activity, run the following command from the solution level folder in VS Code:

```bash  
dotnet ef migrations add item-updates-and-auditing --project EF10_InventoryDBLibrary --startup-project EF10_InventoryManager
```  

or run this command from the project-level folder in VS Code.

```bash
dotnet ef migrations add item-updates-and-auditing --project EF10_InventoryDBLibrary
```  

## In Visual Studio

Alternatively, you can update the database using the traditional command in Visual Studio

```bash
add-migration item-updates-and-auditing
```  