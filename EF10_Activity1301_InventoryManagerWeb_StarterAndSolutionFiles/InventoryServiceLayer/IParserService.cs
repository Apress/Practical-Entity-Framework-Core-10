using EF10_InventoryModels.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_InventoryServiceLayer;

public interface IParserService
{
    List<ParsedItemDataDTO> ParseFromFile(string filePath);
}
