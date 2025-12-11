# Listing 04-05: The IActivatableModel Interface

An interface to define the properties for an Activatable model (has an IsActive flag).

## The code

The `IActivatableModel` interface defines a property for `IsActive` 

```cs  
namespace EF10_InventoryModels.Interfaces;  

public interface IActivatableModel
{
    public bool IsActive { get; set; }
}
```  