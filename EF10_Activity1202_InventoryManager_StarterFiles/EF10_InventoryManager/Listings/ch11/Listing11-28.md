# Listing 11-28: The code to complete the transaction

Use this code to complete the Bulk Load

## The Code

```cs
// Now, wrap in transaction
using (var transaction = _context.Database.BeginTransaction())
{
    try
    {
        // Add and save items first to generate IDs and insert m2m joins
        _context.Items.AddRange(parsedItems.Select(p => p.Item));
        _context.SaveChanges();

        // Now build and add ItemContributors with generated ItemIds
        foreach (var parsed in parsedItems)
        {
            foreach (var kvp in parsed.ContributorData)
            {
                itemContributorsToAdd.Add(new ItemContributor
                {
                    ItemId = parsed.Item.Id, // Now set after save
                    ContributorId = kvp.Key,
                    ContributorType = Enum.Parse<ContributorType>(kvp.Value, true)
                });
            }
        }
        _context.ItemContributors.AddRange(itemContributorsToAdd);
        _context.SaveChanges();

        transaction.Commit();
        return true;
    }
    catch (Exception)
    {
        transaction.Rollback();
        throw; // Or handle as needed
    }
    finally
    {
        // Detach genre stubs to avoid tracking conflicts in subsequent calls
        foreach (var stub in genreStubs.Values)
        {
            _context.Entry(stub).State = EntityState.Detached;
        }
    }
}
```  