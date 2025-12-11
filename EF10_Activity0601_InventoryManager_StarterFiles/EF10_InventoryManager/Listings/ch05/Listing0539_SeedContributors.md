# Listing 5-39. Seed Contributor Data in the InventoryDbContext

Create the initial set of `Contributor` data in the `OnModelCreating` method of the `InventoryDbContext` class using the `HasData` method. 
This seeds the database with predefined categories when the database is created or migrated.

## Change to DBContext.OnModelCreating  

```cs
modelBuilder.Entity<Contributor>(entity =>
{
    entity.Property(c => c.ContributorName)
        .IsRequired()
        .HasMaxLength(100);
    entity.HasIndex(c => c.ContributorName).IsUnique();
    entity.Property(c => c.IsActive)
        .HasDefaultValue(true);
    entity.HasData(    
        SeedData.Contributors
    );
});
```
