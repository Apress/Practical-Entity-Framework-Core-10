using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF10_NewFeaturesModels;

public class JunkToBulkDelete : DefaultBaseModel
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}
