using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_InventoryModels.DTOs;

//added in Activity 0702 - Task 2 - Step 3 (Listing 7-22)
public class ItemWithCsvDetailsDTO
{
    public int ItemId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string GenresCsv { get; set; } = string.Empty;
    public string ContributorsCsv { get; set; } = string.Empty;
    public decimal TotalValue { get; set; }
}

