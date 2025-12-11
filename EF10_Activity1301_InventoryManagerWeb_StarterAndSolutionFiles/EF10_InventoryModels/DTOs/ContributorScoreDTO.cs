using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_InventoryModels.DTOs;

//Added for Activity 0702 - Task 1 - Step 3 (Listing 7-18)
public class ContributorScoreDTO
{
    public long RankPosition { get; set; }
    public int ContributorId { get; set; }
    public string ContributorName { get; set; } = string.Empty;
    public decimal ContributorScore { get; set; }
}

