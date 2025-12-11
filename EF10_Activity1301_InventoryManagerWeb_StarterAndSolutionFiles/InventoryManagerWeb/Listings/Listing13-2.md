# Listing 13-2: The migrations are called in the Program.cs file

The MigrationHostedService is used to run the migrations for both contexts

## The code

In the Program.cs file, right before the app = builder.Build() command, you'll see the two calls to migrate the contexts

```cs
builder.Services.AddHostedService<MigrationHostedService<ApplicationDbContext>>();
builder.Services.AddHostedService<MigrationHostedService<InventoryDbContext>>();
```  