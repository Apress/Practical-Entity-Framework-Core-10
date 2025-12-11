# Listing 14-5: Soft Delete Interceptor Test

Use the code from this listing to finish the test for the `SoftDeleteInterceptor`

## The code

Place this code in the method `InterceptorsAndLoggingDemo` RunAsync method as directed by the `TODO` comment

```cs
var cat = new Category()
{
    CategoryName = $"Test Category [{ts}]",
    IsActive = true
};

//add it
_db.Categories.Add(cat);
await _db.SaveChangesAsync();

//now delete it (should be a soft delete)
//(put a breakpoint on SaveChangesAsync in the interceptor to see it hit)
_db.Categories.Remove(cat);
await _db.SaveChangesAsync();
```  