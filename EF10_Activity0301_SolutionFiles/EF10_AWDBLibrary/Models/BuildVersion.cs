using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EF10_AWDBLibrary.Models;

/// <summary>
/// Current version number of the AdventureWorksLT 2012 sample database. 
/// </summary>
[Keyless]
[Table("BuildVersion")]
public partial class BuildVersion
{
    /// <summary>
    /// Primary key for BuildVersion records.
    /// </summary>
    [Column("SystemInformationID")]
    public byte SystemInformationId { get; set; }

    /// <summary>
    /// Version number of the database in 9.yy.mm.dd.00 format.
    /// </summary>
    [Column("Database Version")]
    [StringLength(25)]
    public string DatabaseVersion { get; set; } = null!;

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime VersionDate { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
