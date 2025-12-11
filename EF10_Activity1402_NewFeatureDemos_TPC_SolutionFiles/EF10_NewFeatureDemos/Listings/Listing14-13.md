# Listing 14-13: Updating the Contributor Entity in the OnModelCreating method

The Contributor Entity can no longer use seed data once the JSON column is defined. 

## The Code

The `HasData(...)` code is replaced with code to name the Address as an owned entity to be stored in a JSON column:

### The snippet:

```cs
//Removed for Listing 14-13: can't use json and hasdata together
//entity.HasData(
//    SeedData.Contributors
//);

//Added for Listing 14-13
entity.OwnsOne(a => a.Address, a =>
{
    a.ToJson();
});
```  

### The full Contributor Fluent API definition

```cs
modelBuilder.Entity<Contributor>(entity => {
    entity.Property(c => c.ContributorName).IsRequired().HasMaxLength(50);
    entity.HasIndex(c => c.ContributorName).IsUnique();
    entity.Property(c => c.IsActive)
        .HasDefaultValue(true);
    entity.OwnsOne(a => a.Address, a =>
    {
        a.ToJson();
    });
});
```  