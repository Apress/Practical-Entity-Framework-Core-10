namespace EF10_InventoryModels.DTOs;

//listing 7-18
public class ContributorScoreDTO
{
    public long RankPosition { get; set; }
    public int ContributorId { get; set; }
    public string ContributorName { get; set; } = string.Empty;
    public decimal ContributorScore { get; set; }
}
