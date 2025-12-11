using EF10_InventoryModels;
using EF10_InventoryModels.DTOs;

namespace EF10_InventoryServiceLayer;

public class ParserService : IParserService
{
    public List<ParsedItemDataDTO> ParseFromFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var parsedItems = new List<ParsedItemDataDTO>();

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split('|');
            if (parts.Length != 8)
            {
                throw new InvalidDataException($"Invalid line format: {line}");
            }

            // Main orchestration: Create Item
            var item = CreateItem(parts);

            var parsedItem = new ParsedItemDataDTO { Item = item };

            // Parse Genres
            parsedItem.GenreIds = ParseGenres(parts[6].Trim());

            // Parse Contributors
            parsedItem.ContributorData = ParseContributors(parts[7].Trim());


            parsedItems.Add(parsedItem);
        }

        return parsedItems;
    }

    private static Item CreateItem(string[] parts)
    {
        var name = parts[0].Trim();
        var description = parts[1].Trim();
        var quantity = int.Parse(parts[2].Trim());
        var categoryId = int.Parse(parts[3].Trim());
        var createdByUserId = parts[4].Trim();
        var createdDate = DateTime.Parse(parts[5].Trim());

        return new Item
        {
            Name = name,
            Description = description,
            Quantity = quantity,
            CategoryId = categoryId,
            CreatedByUserId = createdByUserId,
            CreatedDate = createdDate,
            IsActive = true, // Assuming defaults as per schema
            IsOnSale = false,
            Genres = new List<Genre>(),
            ItemContributors = new List<ItemContributor>()
        };
    }

    private List<int> ParseGenres(string genreIdsStr)
    {
        if (string.IsNullOrEmpty(genreIdsStr))
        {
            return new List<int>();
        }

        return genreIdsStr.Split(',').Select(g => int.Parse(g.Trim())).ToList();
    }

    private Dictionary<int, string> ParseContributors(string contributorsStr)
    {
        var dict = new Dictionary<int, string>();

        if (string.IsNullOrEmpty(contributorsStr))
        {
            return dict;
        }

        var contributorParts = contributorsStr.Split(',');
        foreach (var contrib in contributorParts)
        {
            var contribSplit = contrib.Split(':');
            if (contribSplit.Length != 2)
            {
                throw new InvalidDataException($"Invalid contributor format: {contrib}");
            }
            var contributorId = int.Parse(contribSplit[0].Trim());
            var contributorType = contribSplit[1].Trim();

            // Use dictionary: key=contributorId, value=type (assumes unique IDs per item; if duplicates, last wins)
            dict[contributorId] = contributorType;
        }

        return dict;
    }
}
