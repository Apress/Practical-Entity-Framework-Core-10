# Listing 04-14: Creating a System User Id

To simulate the auditing, add a system user id

## The code

Add this at the top of the InventoryDbContext file:

```cs
private const string _systemUserId = "2fd28110-93d0-427d-9207-d55dbca680fa";
```  