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
            .ForMember(dto => dto.Id, options => options.MapFrom(src => src.Id))
            .ForMember(dto => dto.Type, options => options.MapFrom(src => src.Type))
            .ForMember(dto => dto.BannerPictureUri, options => options.MapFrom(src => src.BannerPictureUri))
            .ForMember(dto => dto.PictureUri, options => options.MapFrom(src => src.PictureUri))
            .ForMember(dto => dto.Status, options => options.MapFrom(src => src.Status));
        CreateMap<CatalogGenderType, CatalogGenderTypeDto>()
            .ForMember(dto => dto.GenderType, options => options.MapFrom(src => src.GenderType));
        CreateMap<CatalogBrand, CatalogBrandDto>()
             .ForMember(dto => dto.Id, options => options.MapFrom(src => src.Id))
            .ForMember(dto => dto.Brand, options => options.MapFrom(src => src.Brand))
            .ForMember(dto => dto.PictureUri, options => options.MapFrom(src => src.PictureUri))
            .ForMember(dto => dto.BannerPictureUri, options => options.MapFrom(src => src.BannerPictureUri))
            .ForMember(dto => dto.Status, options => options.MapFrom(src => src.Status));





    }
}
