namespace EF10_InventoryModels.DTOs;

//Listing 7-30
public class ItemDetailSummaryDTO
{
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public string CategoryName { get; set; }
    public string Genres { get; set; }
    public string Contributors { get; set; }
    public decimal TotalValue { get; set; }
}

