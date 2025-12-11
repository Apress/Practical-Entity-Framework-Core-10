# Listing 14-19: Using a named default constraint

In this quick demo, you'll just set a named default constraint

## The code

Modify the default constraint on the Item for IsOnSale to be set to false.

```cs
entity.Property(i => i.IsOnSale)
    .HasDefaultValue(false, "DF_ItemIsOnSale");
entity.Property(i => i.IsActive)
    .HasDefaultValue(true, "DF_ItemIsActive");
```  

>**NOTE:** Renaming the constraint will require a migration.