using EF10_NewFeaturesModels;
using EF10_NewFeaturesModels.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace EF10_NewFeaturesDbLibrary;

public sealed class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public SoftDeleteInterceptor() { }
    private void ApplySoftDelete(DbContext? ctx)
    {
        if (ctx == null) return;

        foreach (var entry in ctx.ChangeTracker.Entries<ISoftDeletableModel>())
        {
            if (entry.State == EntityState.Deleted)
            {
                // turn DELETE into UPDATE
                entry.State = EntityState.Modified;
                entry.CurrentValues[nameof(ISoftDeletableModel.IsDeleted)] = true;
            }
        }
    }

    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        ApplySoftDelete(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        ApplySoftDelete(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
