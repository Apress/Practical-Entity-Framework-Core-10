# Commands run in the Activity

Here you will find commands as run in the activity.

## Add Migrations

1. Run the command to add the `category-genre-contributor-tables-and-relationships` migration: 

    ```bash
    dotnet ef migrations add category-genre-contributor-tables-and-relationships --project EF10_InventoryDBLibrary --startup-project EF10_InventoryManager
    ```  

1. Run the command to add the `seed-initial-data` migration:

    ```bash
    dotnet ef migrations add seed-initial-data --project EF10_InventoryDBLibrary --startup-project EF10_InventoryManager
    ```  

## Remove Migrations

Use the following command to remove any migration that has not been applied:

```bash
dotnet ef migrations remove --project EF10_InventoryDBLibrary --startup-project EF10_InventoryManager
```  

## Update Database

Use the following command to update the database:

```bash
dotnet ef database update --project EF10_InventoryDBLibrary --startup-project EF10_InventoryManager  
```  