using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF10_AWDBLibrary.Models;

[Keyless]
public partial class VProductAndDescription
{
    [Column("ProductID")]
    public int ProductId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string ProductModel { get; set; } = null!;

    [StringLength(6)]
    public string Culture { get; set; } = null!;

    [StringLength(400)]
    public string Description { get; set; } = null!;
}
