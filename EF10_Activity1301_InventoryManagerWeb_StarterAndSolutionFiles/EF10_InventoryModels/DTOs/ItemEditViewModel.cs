using EF10_InventoryModels;

namespace EF10_InventoryModels.DTOs;

public class ItemEditViewModel
{
    public Item Item { get; set; }
    public List<int> SelectedGenreIds { get; set; }
    public List<int> SelectedContributorIds { get; set; }
}
