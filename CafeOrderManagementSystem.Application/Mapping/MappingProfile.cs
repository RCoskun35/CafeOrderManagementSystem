using AutoMapper;
using CafeOrderManagementSystem.Application.Features.CategoryFeature.CreateCategory;
using CafeOrderManagementSystem.Application.Features.MenuFeature.CreateMenu;
using CafeOrderManagementSystem.Domain.Entities;

namespace CafeOrderManagementSystem.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCategoryCommand,Category>();
            CreateMap<CreateMenuCommand,Menu>();
            


        }
    }
}
