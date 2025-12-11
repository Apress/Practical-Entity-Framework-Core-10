# Listing 04-15: Update the Ensure Items Exist Async method

With the new fields, you will need to make sure every added Item has enough information (leveraging the audit columns automatically)  

## The code

Update the Ensure Items Exist Async method, replacing the List creation with the following code:

```cs
List<Item> items = new()
{
    new Item() { Name = "Top Gun", CurrentValue = 10.99m, Description = "Maverick and Goose"
                        , IsActive = true, IsOnSale = false, Notes = "I feel the need, the need for speed"
                        , PurchasedDate = new DateTime(2025, 7, 4), PurchasePrice = 9.99m, Quantity = 1, },
    new Item() { Name = "Star Wars", Quantity = 4, IsActive = true, IsOnSale = false},
    new Item() { Name = "Star Trek", Quantity = 1, IsActive = true, IsOnSale = true},
    new Item() { Name = "The Godfather", Quantity = 250, IsActive = true, IsOnSale = false},
    new Item() { Name = "The Lord of the Rings: The Fellowship of the Ring", Quantity = 10, IsActive = true, IsOnSale = false}
};
```  