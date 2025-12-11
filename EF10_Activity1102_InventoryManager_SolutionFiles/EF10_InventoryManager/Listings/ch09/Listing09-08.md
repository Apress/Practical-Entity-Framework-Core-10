# Listing 9-8: Using the ProjectTo method to map results

Using AutoMapper projections, you can get your type from the query projected directly using the mapping capabilities of AutoMapper.

## The code

Use this code in the UsingAutoMapperProjectTo method to create a projection directly into the ItemByCategoryDTO object.

```cs
var items = _db.Items
       .OrderBy(i => i.Category.CategoryName).ThenBy(i => i.Name)
       .ProjectTo<ItemByCategoryDTO>(_mapper.ConfigurationProvider)
       .ToList();
```  