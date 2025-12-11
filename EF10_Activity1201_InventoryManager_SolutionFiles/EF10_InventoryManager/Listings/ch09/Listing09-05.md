# Listing 9-5: Using `Select` to project properties of an object to a known type

In this example, you will use the Select method to project properties of an object to a known (defined) type. 

## The Code

Use this code, replacing the `throw new NotImplementedException()` line that follows the comment `TODO: Add the code from listing 9-5` in the method `ProjectToAKnownType` with the actual LINQ query below:

```csharp
var items = _db.Items
    .OrderBy(i => i.Category.CategoryName)
        .ThenBy(i => i.Name)
    .Select(i => new ItemByCategoryDTO
    {
        Id = i.Id,
        Name = i.Name,
        Quantity = i.Quantity,
        CategoryId = i.CategoryId,
        Description = i.Description,
        Notes = i.Notes,
        IsActive = i.IsActive,
        IsOnSale = i.IsOnSale,
        PurchasePrice = i.PurchasePrice,
        CategoryName = i.Category.CategoryName
    })
    .ToList();
```  