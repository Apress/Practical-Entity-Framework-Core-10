namespace EF10_NewFeaturesModels.Interfaces;

public interface ISoftDeletableModel
{
    bool IsDeleted { get; set; }
}
