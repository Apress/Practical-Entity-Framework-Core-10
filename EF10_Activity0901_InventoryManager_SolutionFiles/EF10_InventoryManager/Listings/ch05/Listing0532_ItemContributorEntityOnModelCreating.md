# Listing 5-32 - Using the Fluent API to constrain the ItemContributor Entity 

Create the Fluent API configuration for the `ItemContributor` entity to enforce a unique composite index on `ItemId` and `ContributorId`,
and to configure the `ContributorType` property to be stored as a string with a maximum length of 100 characters.

## Item Entity OnModelCreating Definition

```cs  
    //existing code ... 

    modelBuilder.Entity<ItemContributor>(entity =>
    {
        entity.HasIndex(ic => new { ic.ItemId, ic.ContributorId })
            .IsUnique();
        entity.Property(ic => ic.ContributorType)
            .HasConversion<string>()
            .HasMaxLength(100)
            .IsRequired();
    });
    //Note: Full code available below
```  

## Notes

Drop this code in the OnModelCreating method, just under the stuff you did previously for Contributor

```cs
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Item>(entity =>
    {
        entity.Property(i => i.Name)
            .IsRequired()
            .HasMaxLength(100);

        entity.HasIndex(i => new { i.Name, i.CategoryId }).IsUnique();  //<-- change is right here

        entity.Property(i => i.Quantity)
            .IsRequired();

        entity.Property(i => i.Description)
            .HasMaxLength(500);

        entity.Property(i => i.Notes)
            .HasMaxLength(500);

        entity.Property(i => i.IsOnSale)
            .HasDefaultValue(false);

        entity.Property(i => i.IsActive)
            .HasDefaultValue(true);

        // New check constraint syntax (EF Core 8+)
        entity.ToTable(t =>
        {
            t.HasCheckConstraint("CK_Item_Quantity_NonNegative", "[Quantity] >= 0");
            t.HasCheckConstraint("CK_Item_PurchasePrice_NonNegative", "[PurchasePrice] IS NULL OR [PurchasePrice] >= 0");
            t.HasCheckConstraint("CK_Item_CurrentValue_NonNegative", "[CurrentValue] IS NULL OR [CurrentValue] >= 0");
        });
    });  

    modelBuilder.Entity<Genre>(entity =>
    {
        entity.HasIndex(g => g.GenreName).IsUnique();
        entity.Property(g => g.IsActive)
            .HasDefaultValue(true);
    });

    modelBuilder.Entity<Category>(entity =>
    {
        entity.Property(c => c.IsActive)
            .HasDefaultValue(true);
    });  

    modelBuilder.Entity<Contributor>(entity =>
    {
        entity.HasIndex(c => c.ContributorName).IsUnique();
        entity.Property(c => c.IsActive)
            .HasDefaultValue(true);
    });

    modelBuilder.Entity<ItemContributor>(entity =>
    {
        entity.HasIndex(ic => new { ic.ItemId, ic.ContributorId })
            .IsUnique();
        entity.Property(ic => ic.ContributorType)
            .HasConversion<string>()
            .HasMaxLength(100)
            .IsRequired();
    });
    //....other code
}
```  

