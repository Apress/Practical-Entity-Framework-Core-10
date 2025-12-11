# Listing 5-16 - Modified Item with Constraints

## Item

The full Item class with constraints follows:

```cs
public class Item : FullAuditModel
{
    [Required, StringLength(100)]
    public string Name { get; set; }

    [Required, Range(0, int.MaxValue)] // Prevent negative quantities
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
}
```  

## Notes

Pre-existing class in the InventoryDbModels project, modified to have full constraints on each field as shown below 

- Name: Required and Length max of 100 chars
- Quantity: Required, Range of 0 - max int
- Description: Length max at 500
- Notes: Length max at 500
- IsOnSale: Default value of false and preset to false
- PurchasedDate: can be null, no constraints on date
- SoldDate: can be null, no constraints on date
- PurchasePrice: Not Required, can be null, Range of 0 to max double
- CurrentValue: Not Required, can be null, Range of 0 to max double

Reminder that these changes mostly don't affect the schema, so additional changes are coming (Listing 5-17) for using the Fluent API to modify with check constraints.
