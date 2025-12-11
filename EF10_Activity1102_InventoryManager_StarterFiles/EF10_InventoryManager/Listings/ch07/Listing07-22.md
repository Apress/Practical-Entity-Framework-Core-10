# Listing 7-22: The code to create the `ItemWithCsvDetailsDTO` DTO

Use this code to create a new DTO in the `EF10_InventoryModels` project under the `DTOs` folder.

## The code

Notice how the fields map to results for the function

```cs
//listing 7-22
public class ItemWithCsvDetailsDTO
{
    public int ItemId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string GenresCsv { get; set; } = string.Empty;
    public string ContributorsCsv { get; set; } = string.Empty;
    public decimal TotalValue { get; set; }
}
```  

>**Note:** if you decide to rename fields in your function, create a v1 file and do another migration, then make sure to modify the field names here to match as well.