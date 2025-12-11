# Listing 11-08: Override FilterName for Item

Use this code to make Item contain a property: FilterName

## The code

Add the following property to your Item class

```cs
[NotMapped]
public override string FilterName => Name;
```  

This can be placed anywhere in the file, but I put it right after the Name field