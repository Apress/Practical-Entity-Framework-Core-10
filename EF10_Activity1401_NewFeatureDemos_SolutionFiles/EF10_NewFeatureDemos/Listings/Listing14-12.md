# Listing 14-12: Utilizing the Address entity in Contributors

In order to make this work, the Contributor object needs to leverage Address as if it were anoter entity in the database.

## The Code

The interesting part of this is that there is no address table, and the data is stored as JSON in an nvarchar(max) field after the migration is applied

### Shown in the book

```cs
public class Contributor : ActivatableIdentityModel
{
    //...other code that you should not change

    //added for Listing 14-4
    public Address? Address { get; set; } = null;
}
```  

### The full entity after modification

```cs
[Index(nameof(ContributorName), IsUnique = true)]
public class Contributor: DefaultBaseModel
{
    [Required]
    [StringLength(50)]
    public string ContributorName { get; set; }

    public virtual List<ItemContributor> ContributorItems { get; set; } = new List<ItemContributor>();

    //Added for Listing 14-12 to work with Owned Entity Types (JSON columns)
    public Address? Address { get; set; } = null;
}
```  