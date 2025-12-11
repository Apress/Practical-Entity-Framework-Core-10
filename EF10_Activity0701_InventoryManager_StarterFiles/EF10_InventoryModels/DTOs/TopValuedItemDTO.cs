namespace EF10_InventoryModels.DTOs;

public class TopValuedItemDTO
{
    public int ItemId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public decimal TotalValue { get; set; }
}
