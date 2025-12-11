# Listing 04-08: Implementing the Full Audit Model and some additional properties for the Item Class.

The Item class needs to track:

-	int Quantity
-	string? Description
-	string? Notes
-	bool IsOnSale
-	DateTime? PurchasedDate
-	DateTime? SoldDate
-	decimal? PurchasePrice
-	decimal? CurrentValue

And needs to implement FullAuditModel.

## The code

Modify the Item class to contain the following code:

```cs
public class Item : FullAuditModel
{
    [Required, StringLength(100)]
    public string Name { get; set; }
    public int Quantity { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public bool IsOnSale { get; set; }
    public DateTime? PurchasedDate { get; set; }
    public DateTime? SoldDate { get; set; }
    public decimal? PurchasePrice { get; set; }
    public decimal? CurrentValue { get; set; }
}
```  