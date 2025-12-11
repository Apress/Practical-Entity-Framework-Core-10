# Listing 7-3: A first look at setting a known DTO object as a Veiw

The Flent API allows the definition to be modified with statements like `HasNoKey()` and `ToView()`.

## The code

The code below shows the snippet that is used to map a known object as a view:

```cs
modelBuilder.Entity<GetItemsForListingDto>(x =>
{
    x.HasNoKey();
    x.ToView("ItemsForListing");
});
```  