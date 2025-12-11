# Listing 10-8: 

Set the original column to [NotMapped] so that it will be dropped from the table in the next migration

## Code

The use of [NotMapped] will cause the database to drop the column from the snapshot and tracking.

```cs
[StringLength(50)]
[NotMapped]
public string? PIINumber { get; set; }
```  