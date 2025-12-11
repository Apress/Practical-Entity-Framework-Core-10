# Listing 11-19: The updated IItemRepository Inteface

Use the base interface if possible/where possible

## The new code

Update the IItemRepository interface to the following

```cs
public interface IItemRepository : IGenericRepository<Item>
{
    Task<Item?> GetItemByNameWithCategoryAsync(string name);
    Task<Item?> GetItemByNameWithGenreAsync(string name);
    Task<Item?> GetItemByNameWithGenreByNameAsync(string itemName, string genreName);
    Task<List<Item>> GetItemsByFilterAsync(string filter); //THIS Is overkill but was a previous example so kept it
    Task<List<Item>> GetAllItemsWithCategoryAsync();
    Task<int> UpdateRangeAsync(List<Item> items); // Custom method to update range of items
}
```  

>**Note**: some methods must remain, and other calls will be broken that will need to leverage the generic implementation instead of the original calls.