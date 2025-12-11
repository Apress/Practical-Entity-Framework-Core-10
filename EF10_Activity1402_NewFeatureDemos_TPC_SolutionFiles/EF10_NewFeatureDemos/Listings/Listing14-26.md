# The classes used the FluentAPI and Modelbuilder to define 

TPC definition:

## The code

The OnModelCreating was modified for the new classes as follows:

```cs
//...additional code above this for filters and such

/** ADDED FOR TPC INHERITANCE **/
modelBuilder.Entity<Book>(entity =>
{
    entity.Property(b => b.Id).UseIdentityColumn();
    entity.HasData(SeedData.Books);
});

modelBuilder.Entity<Movie>(entity =>
{
    entity.Property(m => m.Id).UseIdentityColumn();
    entity.HasData(SeedData.Movies);
});
/** END ADDED FOR TPC INHERITANCE **/

modelBuilder.Entity<Item>(entity => {
    entity.Property(i => i.ItemName).IsRequired().HasMaxLength(100);
    entity.HasIndex(i => new { i.ItemName, i.CategoryId, i.TenantId }).IsUnique();
    entity.Property(i => i.IsOnSale)
        .HasDefaultValue(false); //FOR TPC, had to remove default constraint name here
    entity.Property(i => i.IsActive)
        .HasDefaultValue(true); //FOR TPC, had to remove default constraint name here

    // ... additional code ....

        //added for TPC inheritance:
    entity.Property(i => i.Id).UseIdentityColumn();
    entity.UseTpcMappingStrategy();
});
```  

