# Listing 11-10: The Override of FilterName for Genre.

Use this code to make Genre contain a property: FilterName

## The code

Add the following property to your Genre class

```cs
[NotMapped]
public override string FilterName => GenreName;
```  

This can be placed anywhere in the file, but I put it right after the GenreName field