# Listing 10-21: Setting the sql server parameter 

Use a parameter with `FromSQLRaw` to get around encryption problems.

## The query

Use the following code to leverage a parameter to get data in a `FromSqlRaw` query:

```cs
var name = "Test Item";
var param = new SqlParameter("@name", name)
var items = await _db.Items
    .FromSqlRaw("SELECT * FROM Items WHERE Name = @name", param)
    .ToListAsync();
```  