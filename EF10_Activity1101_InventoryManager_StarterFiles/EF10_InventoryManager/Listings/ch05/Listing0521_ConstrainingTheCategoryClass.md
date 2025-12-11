# Listing 5-21 - Constraining the Category class in the Fluent API

Add the following code to the `OnModelCreating` method in your `InventoryDbContext` 
class to set a default value for the `IsActive` property of the `Category` entity.

## Category Entity OnModelCreating Definition

```cs  
modelBuilder.Entity<Category>(entity =>
{
    entity.Property(c => c.IsActive)
        .HasDefaultValue(true);
});
```  

## Notes

Drop this code in the main class, just under the stuff you did previously for Genre

```cs
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Item>(entity =>
    {
        entity.Property(i => i.Name)
            .IsRequired()
            .HasMaxLength(100);

        entity.HasIndex(i => i.Name).IsUnique();

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

    //....other code
}
```  

Also Note - there is no `entity.HasIndex` definition for Category, since the index was defined in the Data Annotation at the top of the Category class.
