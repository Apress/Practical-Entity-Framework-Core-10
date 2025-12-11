using AutoMapper;
using EF10_InventoryModels;
using EF10_InventoryModels.DTOs;

namespace EF10_InventoryManager;

public class InventoryMapper : Profile
{
    public InventoryMapper()
    {
        CreateMaps();
    }

    //Listing 9-6
    private void CreateMaps()
    {
        CreateMap<Item, ItemByCategoryDTO>()
            .ForMember(dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.Category.CategoryName));
    }
}
