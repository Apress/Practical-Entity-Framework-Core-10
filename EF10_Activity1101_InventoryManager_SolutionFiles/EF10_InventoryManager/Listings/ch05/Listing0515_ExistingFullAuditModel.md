# Listing 5-15 - Existing FullAuditModel

## FullAuditModel

```cs
public abstract class FullAuditModel : ActivatableIdentityModel, IAuditedModel
{
    [Required, StringLength(50)]
    public string CreatedByUserId { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    [StringLength(50)]
    public string? LastModifiedUserId { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
```  

## Notes

Pre-existing class in the InventoryDbModels project.  

Additional constraints on length for CreatedByUserId and LastModifedDate
Additioanl Required attributes for CreatedByUserId and CreatedDate