# Listing 8-19: Use Tracking when Tracking is Disabled

When tracking is disabled, you can still get the data with tracking.  Use the AsTracking() method in your query to get tracked results.

## The code

Use `AsTracking()` in your queries to get an attached (tracked) result.

```cs
var item = await _db.Items.AsTracking().FirstOrDefaultAsync(x => x.name == "some name");
````  