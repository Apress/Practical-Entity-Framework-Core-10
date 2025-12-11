# Listing 14-25: New Classes

The following classes were added for TPC/TPT/TPH

## Code

```cs
public abstract class MediaItem : Item
{
    public string PlotSummary { get; set; } = string.Empty;
}

public class Book : MediaItem
{
    public string ISBN { get; set; } = string.Empty;
}

public class Movie : MediaItem
{
    public string MPAARating { get; set; } = string.Empty;
}
```  