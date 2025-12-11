# Listing 11-11: The Override of FilterName for Contributor.

Use this code to make Contributor contain a property: FilterName

## The code

Add the following property to your Contributor class

```cs
[NotMapped]
public override string FilterName => ContributorName;
```  

This can be placed anywhere in the file, but I put it right after the ContributorName field