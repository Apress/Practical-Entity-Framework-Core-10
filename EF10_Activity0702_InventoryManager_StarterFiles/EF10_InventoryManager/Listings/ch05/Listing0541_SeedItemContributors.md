# Listing 5-41 Seed ItemContributor Data in the InventoryDbContext

Create the initial set of `ItemContributor` data in the `OnModelCreating` method of the `InventoryDbContext` class using the `HasData` method. 
This seeds the database with predefined categories when the database is created or migrated.

## Change to DBContext.OnModelCreating  

```cs
modelBuilder.Entity<ItemContributor>(entity =>
{
    entity.HasIndex(ic => new { ic.ItemId, ic.ContributorId })
        .IsUnique();
    entity.Property(ic => ic.ContributorType)
        .HasConversion<string>()
        .HasMaxLength(100)
        .IsRequired();
    entity.HasData(    
        SeedData.ItemContributors
    );
});

```
