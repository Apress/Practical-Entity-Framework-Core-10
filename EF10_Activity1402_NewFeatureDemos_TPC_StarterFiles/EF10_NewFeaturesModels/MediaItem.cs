using System;
using System.Collections.Generic;
using System.Text;

namespace EF10_NewFeaturesModels;

public abstract class MediaItem : Item
{
    public string PlotSummary { get; set; } = string.Empty;
}
