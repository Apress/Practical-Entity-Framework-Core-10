# Listing 04-16: Update all Current Values

Use the following code to perform an update on all Items to set a current value.

## The code

Use the following code to create a method called `UpdateAllCurrentValue` to set all items to have a current value.

```cs
private void UpdateAllCurrentValue()
{
    
    var items = _db.Items.ToList();
    foreach (var item in items)
    {
        item.CurrentValue = 9.99M;
    }
    _db.Items.UpdateRange(items);
    _db.SaveChanges();
}
```  