# Listing 6-9: Get Contributor by Name

Uses a string filter to find match.  Must be exact match.  

## Get Contributor by Name

The final method to get the contributor by name:

```cs
private async Task<Contributor> GetContributorDataByName(string contributorName)
{   
    return await _db.Contributors
                    .Include(x => x.ItemContributors)
               		.ThenInclude(y => y.Item)
                		.Where(x => x.ContributorName == contributorName)
                		.SingleOrDefaultAsync();
}
```  