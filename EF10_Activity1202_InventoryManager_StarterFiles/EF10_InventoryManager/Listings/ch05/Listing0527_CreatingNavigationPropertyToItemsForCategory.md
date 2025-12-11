# Listing 5-27 - Creating the Navigation to Items in the One to Many Category to Items relationship

Create the navigation property in the `Category` class to represent the *one-to-many* relationship between `Category` and `Item`.  
One `Category` has many `Items`.

## Category

```cs  
    //new code:
    public virtual List<Item>? Items { get; set; }
}
```  

## Notes

The navigation property is added to the end of the current Category class defintion.  The full code follows for clarity:

```cs  
namespace EF10_InventoryModels;

[Index(nameof(CategoryName), IsUnique = true)]
public class Category : ActivatableIdentityModel
{
    [StringLength(50)]
    public string CategoryName { get; set; }

    [StringLength(250)]
    public string? Description { get; set; }

    //One category has Many Items
    public virtual List<Item>? Items { get; set; }
}
```  
