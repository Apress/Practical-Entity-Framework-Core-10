# Listing 04-04: The IAuditedModel Interface

An interface to define the properties for an Audited model.

## The code

The IAuditedModel interface defines properties for `CreatedByUserId`, `CreatedDate`, `LastModifiedUserId`, and `LastModifiedDate`.

```cs
namespace EF10_InventoryModels.Interfaces;  

public interface IAuditedModel
{
    public string CreatedByUserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? LastModifiedUserId { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
```  