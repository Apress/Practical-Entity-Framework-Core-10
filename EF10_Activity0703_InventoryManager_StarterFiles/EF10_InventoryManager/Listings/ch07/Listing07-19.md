# Listing 7-19: Make a direct call to get the Contributor Score

The code to call to the new fnGetContributorScore

## The code

Use this code to replace the statement `//TODO: Use Listing 7-19 to get the contributor scores` in the FunctionsMenu.cs file.

```cs
//listing 7-19
var query = @"SELECT RANK() OVER (ORDER BY dbo.fnGetContributorScore(c.Id) DESC) AS RankPosition, " +
                "c.Id as ContributorID, " +
                "c.ContributorName, " +
                "dbo.fnGetContributorScore(c.Id) AS ContributorScore " +
                "FROM Contributors c " +
                "ORDER BY RankPosition;";

var contributors = await _db.Database
                            .SqlQueryRaw<ContributorScoreDTO>(query)
                            .ToListAsync();
```