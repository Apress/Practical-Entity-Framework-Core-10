using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_InventoryModels.DTOs;

public class ItemByGenreDTO
{
    public int ItemId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public int GenreId { get; set; }
    public string GenreName { get; set; } = string.Empty;
    public string? ItemDescription { get; set; }
    public bool IsActive { get; set; }
}

