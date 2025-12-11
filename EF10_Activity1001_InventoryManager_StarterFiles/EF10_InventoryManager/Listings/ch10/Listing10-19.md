# Listing 10-19: Add the setting to the connection string

To make your code work with the `Always Encrypted` columns, add the statement below to your database connection string

## Connection String

```cs
Column Encryption Setting=Enabled;
```  

The full connection string using a container as the database host is:

```cs
{
  "ConnectionStrings": {
    "InventoryDbConnection": "Server=localhost;Database=InventoryManagerDB_1002;User Id=sa;Password=your-password-here;TrustServerCertificate=True;MultipleActiveResultSets=False;Column Encryption Setting=Enabled;"
  }
}
```  