# Listing 5-25 - Add a Foreign Key and Navigation Property to Item for Category

Add a foreign key and navigation property to the `Item` class to create a one-to-many relationship with the `Category` class.

## Item

```cs
//… existing code
// See Listing0525_ItemForeignKeyCategoryIdAndCategoryNavigation.md in the Listings folder for the full Item class code
// new code
//An item is mapped to a single category
[Required] 
public virtual int CategoryId { get; set; }
public virtual Category? Category { get; set; }
```  

## Notes

The two fields for the one-to-many relationship are added
- CategoryId -> maps to the Id in the Category field
- Category -> a navigation property used to hold the data of the Category that is associated to this Item
                you want this to be nullable so that you don't always have to track the category information
                which allows you to work on an Item in isolation from the Category that is associated to it

The full Item class after adding the new code follows: 

```cs  
public class Item : FullAuditModel
{
    [Required, StringLength(100)]
    public string Name { get; set; }

    [Range(0, int.MaxValue)] // Prevent negative quantities
    public int Quantity { get; set; }

    [StringLength(500)] // Set a reasonable max length for description
    public string? Description { get; set; }

    [StringLength(500)] // Set a reasonable max length for notes
    public string? Notes { get; set; }

    [DefaultValue(false)] // Default value for IsOnSale
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
}
```  

As a reminder, the CategoryId and Category navigation work together by convention, using the same base `Category`. If you named Category to ItemCategory but didn't set CategoryId to ItemCategoryId, the relationship would fail.  You could add a data annotation to state that CategoryId is the foreign key for the navigation ItemCategory, but that would create unnecessary confusion in the code.

>**Note: Don't do any of this, it's for learning only:

Don't do this, but for clarity, this is what I am saying:

```cs
[ForeignKey(nameof(ItemCategory))] 
[Required] 
public virtual int CategoryId { get; set; }
public virtual Category? ItemCategory { get; set; }
```  

This *should* work, but you should not do this unless you have a specific reason to do so (i.e. Naming conflicts)

You would still to better to use convention over configuration:

```cs
[Required] 
public virtual int ItemCategoryId { get; set; }
public virtual Category? ItemCategory { get; set; }
```  