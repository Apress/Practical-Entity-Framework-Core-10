using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_InventoryModels.Interfaces;

public interface INameFilterableModel 
{
    public string FilterName { get; }
}
