# Listing 5-28 - Creating a Composite Unique Index on Item Name and CategoryId

Create a composite unique index on the `Item` entity that includes both the `Name` and `CategoryId` properties. 
This ensures that within a given category, item names are unique, but the same item name can exist in different categories.

## Item Entity OnModelCreating Definition

```cs  
    //… existing code
    // See the full code in below
    //modified code:
    entity.HasIndex(i => new { i.Name, i.CategoryId }).IsUnique();
   
    //… existing code 
```  

## Notes

Drop this code in the OnModelCreating method, just under the stuff you did previously for Category

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
    //....other code
}
```  