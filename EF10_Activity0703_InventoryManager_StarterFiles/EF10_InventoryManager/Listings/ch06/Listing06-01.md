# Listing 6-1: The Class Declaration for DbSet<TEntity>  

The Class is defined to implement IEnumerable<TEntity> and IQueryable<TEntity>

## A Quick look at the class declaration

```cs
public abstract class DbSet<TEntity> : 
        Microsoft.EntityFrameworkCore.Infrastructure.IInfrastructure<IServiceProvider>
        , System.Collections.Generic.IEnumerable<TEntity>
        , System.ComponentModel.IListSource
        , System.Linq.IQueryable<TEntity> 
                    where TEntity : class
{
    //…
}
```  


## End

This concludes Listing 6-1