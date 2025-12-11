# Listing 04-07: The FulAuditModel Class

A concrete implementation of a full audit model implements all the interfaces.

## The code

The `FulAuditModel` abstract class defines a base class implementation for an audited model that is activatable and has identity 

```cs  
using EF10_InventoryModels.Interfaces;

namespace EF10_InventoryModels;

public abstract class FullAuditModel : IIdentityModel, IAuditedModel, IActivatableModel
{
    public int Id { get; set; }
    public string CreatedByUserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? LastModifiedUserId { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public bool IsActive { get; set; }
}
```  