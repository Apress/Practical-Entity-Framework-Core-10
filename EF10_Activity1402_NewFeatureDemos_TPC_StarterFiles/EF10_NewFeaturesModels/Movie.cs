using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_NewFeaturesModels;

public class Movie : MediaItem
{
    public string MPAARating { get; set; } = string.Empty;
}
