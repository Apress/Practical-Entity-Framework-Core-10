using EF10_InventoryModels.DTOs;

namespace EF10_InventoryServiceLayer;

public interface IParserService
{
    List<ParsedItemDataDTO> ParseFromFile(string filePath);
}
