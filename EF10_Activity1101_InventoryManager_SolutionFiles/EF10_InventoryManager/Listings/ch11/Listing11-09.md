# Listing 11-09: The Override of FilterName for Category.

Use this code to make Category contain a property: FilterName

## The code

Add the following property to your Category class

```cs
[NotMapped]
public override string FilterName => CategoryName;
```  

This can be placed anywhere in the file, but I put it right after the CategoryName field