using System.ComponentModel.DataAnnotations;

namespace EF10_InventoryModels;

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

