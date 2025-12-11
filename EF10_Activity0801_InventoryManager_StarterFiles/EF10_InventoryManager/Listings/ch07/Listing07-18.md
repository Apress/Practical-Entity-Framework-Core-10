# Listing 7-18: The ContributorScoreDTO

Use this code to validate/create your ContributorScoreDTO

## The code

This is the expected code for the ContributorScoreDTO

```cs
//listing 7-18
public class ContributorScoreDTO
{
    public long RankPosition { get; set; }
    public int ContributorId { get; set; }
    public string ContributorName { get; set; } = string.Empty;
    public decimal ContributorScore { get; set; }
}
```  