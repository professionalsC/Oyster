using AutoMapper;
using Oyster.ApplicationCore.Entities;
using Oyster.PublicApi.CatalogBrandEndpoints;
using Oyster.PublicApi.CatalogGenderTypeEndpoint;
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
        CreateMap<CatalogGenderType, CatalogGenderTypeDto>()
            .ForMember(dto => dto.GenderType, options => options.MapFrom(src => src.GenderType));
        CreateMap<CatalogBrand, CatalogBrandDto>()
            .ForMember(dto => dto.Brand, options => options.MapFrom(src => src.Brand));

    }
}
