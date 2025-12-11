using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_InventoryModels.DTOs;

//Added in Activity 0703 - Step 3
public class ItemDetailSummaryDTO
{
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public string CategoryName { get; set; }
    public string Genres { get; set; }
    public string Contributors { get; set; }
    public decimal TotalValue { get; set; }
}

