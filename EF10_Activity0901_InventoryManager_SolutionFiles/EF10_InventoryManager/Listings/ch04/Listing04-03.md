# Listing 04-03: A simple query to introduce SqlQuery

EF Core 7 introduced the ability to use SqlQuery to get data from the database that is not mapped to any existing entity.

## The code

Note that this code is never used in the codebase, but is a `for example` scenario only.

```cs
var names = await context.Database
    .SqlQuery<string>($"SELECT [Name] FROM [Items]")
    .ToListAsync();
```  