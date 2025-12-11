# Listing 5-18 - Creating the Category class

Create a new class named `Category` in the `Models` folder.  This class will represent a product category.  
It will inherit from `ActivatableIdentityModel`, which means it will have an `Id` and an `IsActive` field.  
The `Category` class will have two additional fields: `CategoryName` and `Description`.  
The `CategoryName` field will be required and unique, while the `Description` field will be optional.


## Category

```cs  
[Index(nameof(CategoryName), IsUnique = true)]
public class Category : ActivatableIdentityModel
{
    [Required, StringLength(50)]
    public string CategoryName { get; set; }

    [StringLength(250)]
    public string? Description { get; set; }
}
```  

## Notes

Two fields: 
- CategoryName (you could rename to just `Name` if you want) - Required and limited to 50 chars
- Description (not required, limited to 250 chars - set a longer length if you want)

Notice the use of the Unique Index defined on the Data Annotation.
This can be done and will affect the schema.  However, it's a bit dangerous.  IF the table was already created, there is a change the migration might not pick it up.  It's a small chance, but it could happen.  However, with this being the first creation of the table, it *should* work.  It is worthy of watching in the migration, however, to make sure that the index is created as expected.  

Through inheritance, Category will get an Id and IsActive field.  The IsActive field will need to be constrained in the OnModelCreating method (Listing 5-21).  Because of the Data Annotation, you will NOT need to add an index in the Fluent API.

## Additional References

- [EF Core Data Annotations](https://learn.microsoft.com/ef/core/modeling/data-annotations)
- [EF Core Indexes](https://learn.microsoft.com/ef/core/modeling/indexes)

```xml
  <ItemGroup>
	<PackageReference Include="Microsoft.EntityFrameworkCore" Version="$(MicrosoftEntityFrameworkCoreVersion)" />
  </ItemGroup>  
```  

```PowerShell
dotnet add package Microsoft.EntityFrameworkCore --version 10.0.0-rc.1.25451.107
```