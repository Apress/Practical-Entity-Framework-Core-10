# Listing 14-6: Enabling filters

Utilize the filters to default the data that is filtered from showing to the user

## The Code

Enable the filters using the following code.  Note that the tenant filter is currently just for show, but if you "pretend" you logged in under tenant 2 by changing it, you should see no items.

```cs
modelBuilder.Entity<Category>()
                .HasQueryFilter("SoftDelete", c => !c.IsDeleted)
                .HasQueryFilter("Active", c => c.IsActive);

modelBuilder.Entity<Contributor>()
                .HasQueryFilter("SoftDelete", c => !c.IsDeleted)
                .HasQueryFilter("Active", c => c.IsActive);

modelBuilder.Entity<Genre>()
                .HasQueryFilter("SoftDelete", g => !g.IsDeleted)
                .HasQueryFilter("Active", c => c.IsActive);

modelBuilder.Entity<JunkToBulkDelete>()
                .HasQueryFilter("SoftDelete", j => !j.IsDeleted)
                .HasQueryFilter("Active", c => c.IsActive);

modelBuilder.Entity<ItemContributor>()
                .HasQueryFilter("SoftDelete", ic => !ic.IsDeleted)
                .HasQueryFilter("Active", c => c.IsActive);

modelBuilder.Entity<Item>()
                .HasQueryFilter("SoftDelete", i => !i.IsDeleted)
                .HasQueryFilter("Active", c => c.IsActive)
                .HasQueryFilter("Tenant", i => i.TenantId == 1);

```  