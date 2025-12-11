# Listing 5-29 - Creating the Navigation to Genres in the Many to Many Items to Genres relationship Implicitly  

Create the navigation property in the `Item` class to represent the *many-to-many* relationship between `Item` and `Genre`.

## Item

```cs  
    //… existing code
    //Implicitly map many-to-many to Genres
    public virtual List<Genre>? Genres { get; set; }
}
```  

## Notes

The navigation property is added to the end of the current Category class defintion.  The full code follows for clarity:

```cs  
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EF10_InventoryModels;

public class Item : FullAuditModel
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required, Range(0, int.MaxValue)] // Prevent negative quantities
    public int Quantity { get; set; }

    [StringLength(500)] // Set a reasonable max length for description
    public string? Description { get; set; }

    [StringLength(500)] // Set a reasonable max length for notes
    public string? Notes { get; set; }

    [Required, DefaultValue(false)] // Default value for IsOnSale
    public bool IsOnSale { get; set; } = false;
    public DateTime? PurchasedDate { get; set; }
    public DateTime? SoldDate { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? PurchasePrice { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? CurrentValue { get; set; }

    //An item is mapped to a single category
    [Required]
    public virtual int CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    //Implicitly map many-to-many to Genres
    public virtual List<Genre>? Genres { get; set; }
}
```  

The mapping will create a navigation to Genres and EF will create a join table implicitly once the reverse mapping from Genres to Items is in place.

Using nullable is critical to allow you to work in isolation on just an Item object.