# Listing 7-7: The ItemByGenre DTO

Use this code to complete Step 3 of Task 1 -> Creating the DTO for `GetItemsByGenre` procedure

## Code

The suggested code for the DTO object follows.  Place it in the file `ItemByGenreDTO.cs` under the EF10_InventoryModels/DTOs folder.

```cs
//added from listing 7-7
public class ItemByGenreDTO
{
    public int ItemId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public int GenreId { get; set; }
    public string GenreName { get; set; } = string.Empty;
    public string? ItemDescription { get; set; }
    public bool IsActive { get; set; }
}
```  