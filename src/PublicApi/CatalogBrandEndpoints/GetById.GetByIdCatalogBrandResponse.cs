using System;

namespace Oyster.PublicApi.CatalogBrandEndpoints;

public class GetByIdCatalogBrandResponse : BaseResponse
{
    public GetByIdCatalogBrandResponse(Guid correlationId) : base(correlationId)
    {
    }

    public GetByIdCatalogBrandResponse()
    {
    }

    public CatalogBrandDto CatalogBrand { get; set; }
}
