using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_InventoryModels.DTOs;

public class ContributorSummaryDTO
{
    public int ContributorId { get; set; }
    public string ContributorName { get; set; }
    public string ItemTitles { get; set; }
}
