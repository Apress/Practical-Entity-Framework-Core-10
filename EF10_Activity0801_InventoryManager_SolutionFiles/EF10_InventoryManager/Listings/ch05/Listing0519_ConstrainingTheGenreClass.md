# Listing 5-19 - Constraining the Genre class in the Fluent API

Using the Fluent API, we can add constraints to the Genre entity to ensure data integrity.

## Genre Entity OnModelCreating Definition

The code you need follows:  

```cs  
modelBuilder.Entity<Genre>(entity =>
{
    entity.HasIndex(g => g.GenreName).IsUnique();
    entity.Property(g => g.IsActive)
        .HasDefaultValue(true);
});
```  

## Notes

Drop this code in the main class, just under the stuff you did previously for Item

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

    //NEW CODE GOES HERE: 

    modelBuilder.Entity<Genre>(entity =>
    {
        entity.HasIndex(g => g.GenreName).IsUnique();
        entity.Property(g => g.IsActive)
            .HasDefaultValue(true);
    });

    //....any other code
}
```  