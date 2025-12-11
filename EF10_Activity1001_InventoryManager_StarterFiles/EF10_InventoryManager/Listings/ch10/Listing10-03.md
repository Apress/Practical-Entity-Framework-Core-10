# Listing 10-3: Adding a new migration

## The code

Use the following for VSCode:

```bash
dotnet ef migrations add piinumber-backup-column --project EF10_InventoryDBLibrary --startup-project EF10_InventoryManager
```  

And for VS

```
add-migration piinumber-backup-column
```  