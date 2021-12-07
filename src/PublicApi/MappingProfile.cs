using AutoMapper;
using Oyster.ApplicationCore.Entities;
using Oyster.PublicApi.CatalogBrandEndpoints;
using Oyster.PublicApi.CatalogItemEndpoints;
using Oyster.PublicApi.CatalogTypeEndpoints;

namespace Oyster.PublicApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogItem, CatalogItemDto>();
        CreateMap<CatalogType, CatalogTypeDto>()
            .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Type));
        CreateMap<CatalogBrand, CatalogBrandDto>()
            .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Brand));
    }
}
