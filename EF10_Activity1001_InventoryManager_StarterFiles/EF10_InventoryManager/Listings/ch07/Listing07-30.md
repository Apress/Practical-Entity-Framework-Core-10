# Listing 7-30. The ItemDetailSummaryDTO object

This DTO will map the results of the `vwItemsWithGenresAndContributors` to a POCO.

## The code

Use the following code to create a new class called `ItemSummaryDTO` in the DTOs folder under the models project

```cs
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
```  