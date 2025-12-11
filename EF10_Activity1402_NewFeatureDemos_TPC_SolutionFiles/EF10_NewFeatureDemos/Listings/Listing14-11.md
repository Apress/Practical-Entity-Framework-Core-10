# Listing 14-11: The "Flexible" Address Entity

This code is pre-built so you don't need to implement.  

## The Code

The Address model is implemented in the Models project.  It is "flexible" because all the fields can be null.  As you can see, this is not a real solution for non-relational data, however it does give you options.

```cs
public class Address
{
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? POBox { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
}
```  