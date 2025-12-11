namespace EF10_InventoryModels.DTOs;

public class ParsedItemDataDTO
{
    public Item Item { get; set; }
    public List<int> GenreIds { get; set; } = new List<int>();
    public Dictionary<int, string> ContributorData { get; set; } = new Dictionary<int, string>();
}

