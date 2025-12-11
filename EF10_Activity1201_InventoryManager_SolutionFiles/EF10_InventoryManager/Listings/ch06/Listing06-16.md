# Listing 6-16: Create multiple contributors using AddRange

The ability to create multiple entities at the same time is accomplished using the `AddRange` method.

## Implement the Method

Use the following code to complete the method `CreateMultipleContributorsAsync`. 

```cs
private async Task<bool> CreateMultipleContributorsAsync(List<Contributor> contributors)
{
    if (contributors == null || !contributors.Any())
    {
        Console.WriteLine("No contributors to add.");
        return false;
    }
    var contributorsToAdd = new List<Contributor>();
    // Validate each contributor, and check if it already exists
    foreach (var contributor in contributors)
    {
        if (string.IsNullOrWhiteSpace(contributor.ContributorName))
        {
            Console.WriteLine("Contributor name cannot be null or empty.");
            continue;
        }
        // Check if the contributor already exists
        var exists = await CheckIfContributorExistsAsync(contributor.ContributorName);
        if (exists)
        {
            continue; // Skip adding this contributor
        }
        contributorsToAdd.Add(contributor);
    }
    // If no new contributors to add, return early
    if (!contributorsToAdd.Any())
    {
        Console.WriteLine("No new contributors to add.");
        return true; // No new contributors to add
    }
    // Add the contributors to the context
    _db.Contributors.AddRange(contributorsToAdd);
    // Save changes to the database
    var result = await _db.SaveChangesAsync();
    //counts should match
    Console.WriteLine($"{contributorsToAdd.Count} contributors added successfully.");
    return result == contributorsToAdd.Count;
}
```   