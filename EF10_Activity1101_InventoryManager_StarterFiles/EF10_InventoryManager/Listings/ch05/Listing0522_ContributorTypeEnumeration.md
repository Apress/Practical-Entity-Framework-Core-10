# Listing 5-22 - Contributor Type Enumeration

Create an enumeration called `ContributorType` in the `EF10_InventoryModels` namespace.
Place it in a file named `Enums.cs`. Remove the boilerplate code and add the following code to the new file.

## ContributorType

```cs  
namespace EF10_InventoryModels;

public enum ContributorType 
{ 
    Author, Editor, Illustrator, Translator, Director, 
    Producer, Actor, Composer, Narrator, Publisher, 
    Manufacturer, Distributor, Other 
}
```  

## Notes

I typically put my enums in one file called `Enums.cs` since there is no class definition required.  
It's up to you if you want to do this differently, so long as the enum is in the correct namespace.  
