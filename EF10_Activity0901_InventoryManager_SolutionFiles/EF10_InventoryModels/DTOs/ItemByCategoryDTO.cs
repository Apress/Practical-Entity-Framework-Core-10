namespace EF10_InventoryModels.DTOs;

public class ItemByCategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public bool IsActive { get; set; }
    public bool IsOnSale { get; set; }
    public decimal? PurchasePrice { get; set; }

    public int? Quantity { get; set; }
}