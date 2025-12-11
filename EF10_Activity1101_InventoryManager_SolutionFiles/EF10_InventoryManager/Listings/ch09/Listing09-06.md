# Listing 9-6: The InventoryMapper class

In order to work with AutoMapper, you need to tell AutoMapper how to map entities when the conversions are not immediately mappable (one-to-one property mappings by name)

## The Code

The InventoryMapper class allows further definition of maps that would happen in the solution down the road.

The InventoryMapper class must directly inherit from the `AutoMapper.Profile` class.

>**Note:** In robust solutions, there will be quite a bit more mapping here.  However, some of the default entities and their DTO objects are easily recognized by AutoMapper.

```csharp
public class InventoryMapper : Profile
{
    public InventoryMapper()
    {
        CreateMaps();
    }

    private void CreateMaps()
    {
        CreateMap<Item, ItemByCategoryDTO>()
            .ForMember(dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.Category.CategoryName));
    }
}

```  