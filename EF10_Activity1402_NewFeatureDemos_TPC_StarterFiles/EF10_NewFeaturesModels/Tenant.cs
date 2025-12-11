using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF10_NewFeaturesModels;

public class Tenant : DefaultBaseModel
{
    [StringLength(100)]
    public string TenantName { get; set; }
    public virtual List<Item> Items { get; set; } = new List<Item>();
}
