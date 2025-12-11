namespace EF10_InventoryModels.DTOs;

public class ItemWithCsvDetailsDTO
{
    //listing 7-22
    public int ItemId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string GenresCsv { get; set; } = string.Empty;
    public string ContributorsCsv { get; set; } = string.Empty;
    public decimal TotalValue { get; set; }
}

