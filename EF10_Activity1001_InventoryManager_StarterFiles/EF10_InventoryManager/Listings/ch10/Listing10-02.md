# Listing 10-2: Adding a backup column to the model

Add a backup column to temporarily store the plain-text data during the encryption migration.

## The code

Add the following additional column to the Item model

```cs
[StringLength(50)]
public string? PIINumberBackup { get; set; }
```  
