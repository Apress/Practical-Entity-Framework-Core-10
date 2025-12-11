# Listing 5-40 Seed Item Data in the InventoryDbContext

Create the initial set of `Item` data in the `OnModelCreating` method of the `InventoryDbContext` class using the `HasData` method. 
This seeds the database with predefined categories when the database is created or migrated.

## Change to DBContext.OnModelCreating  

```cs
modelBuilder.Entity<Item>(entity =>
{
       //lots of other code

      //new code
      entity.HasData(
            SeedData.Items
      )};
});
```
