# Listing 10-10: Transform the column

After updating the databse and removing the column, change the `Item` model again to set the `PIINumber` as mapped but also change the type to `byte[]?`. Since there is a migration in place with seed data if you don't leave this field as nullable, it will cause problems.

## Code

Change the type and remove the `StringLength` and `NotMapped` constraints.

```cs
public byte[]? PIINumber { get; set; }
```  