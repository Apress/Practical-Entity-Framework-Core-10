# Listing 5-16 - OnModelCreating change for Item entity

## Item Entity OnModelCreating Definition

```cs
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
```  

## Notes

Place the code after `base.OnModelCreating(modelBuilder);`:

```cs
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    //Item entity code goes here

    //....other code
}
```  

Notice the check constraints placement, as that has changed since EFCore 8+, used to make sure values are blocked from being less than 0