# Listing 7-23. Adding the DTO as a DbSet

Use the DbSet<T> paradigm to add the new function results as a DbSet

## The code

Add the following code to the top of the InventoryDBContext file

```cs
public DbSet<ItemWithCsvDetailsDTO> ItemsWithCsvDetails { get; set; }   
```  