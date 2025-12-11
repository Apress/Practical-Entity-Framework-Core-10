# Listing 14-16: Using a DbSet<TEntity> mapped as a keyless entity

We already did this in chapter 7

## The Code

To get the result projected directly to the DTO, you had to set up the HasNoKey property and create a DbSet<ItemDetailSummaryDTO> for this to work as expected, but it was possible

```cs
var items1 = await _db.Set<ItemDetailSummaryDTO>()
                                    .FromSqlRaw(query)
                                    .OrderBy(i => i.ItemName)
                                    .ToListAsync();

```  

>**NOTE:** You are not implementing this code anywhere, it is for review/learning purposes only.