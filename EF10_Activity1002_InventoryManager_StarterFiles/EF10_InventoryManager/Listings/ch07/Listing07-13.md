# Listing 7-13: Update the database to apply the command

With the migration in place, run the correct command to apply it.

## Listing 7-13: The command to update the database

### VSCode  

The command to update the database from VSCode is:

```bash
dotnet ef database update --project EF10_InventoryDBLibrary --startup-project EF10_InventoryManager
```  

>**Note:** This command assumes you are at the root-level folder

### Visual Studio  

The command to update the database from VS PMC is:
 
```bash
update-database
```

>**Note:** In VS, make sure you have selected the DBLibrary project from the dropdown to avoid an error for `No DbContext Found`.  
