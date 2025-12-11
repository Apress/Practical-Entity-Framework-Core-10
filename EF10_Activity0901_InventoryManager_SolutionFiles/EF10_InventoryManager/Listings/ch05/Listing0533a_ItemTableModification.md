# Listing 5-33a - Adding the ItemContributors to Item

Create the navigation property in the `Item` class to represent the many-to-many relationship between `Item` and `Contributor`
using the `ItemContributor` join entity.

## Item

```cs  
//..existing code 

//new code
//explicitly define join to ItemContributor to create mapping to Contributors through ItemContributors 
//for the many-to-many relationship
public virtual List<ItemContributor>? ItemContributors { get; set; }
//Note: Full code available in Listing0533a_ItemTableModification.md &&
//           Listing0533b_ContributorTableModification.md
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

    //explicitly define join to ItemContributor to create mapping to Contributors through ItemContributors 
    //for the many-to-many relationship
    public virtual List<ItemContributor>? ItemContributors { get; set; }
}
```  

Remember to keep the property nullable so as to allow working with Items in isolation