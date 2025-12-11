# Listing 04-06: The IIdentityModel Interface

An interface to define the properties for an Identity model (has an Id field).

## The code

The `IIdentityModel` interface defines a property for `Id` 

```cs  
namespace EF10_InventoryModels.Interfaces;

public interface IIdentityModel
{ 
    public int Id { get; set; }
}
```  