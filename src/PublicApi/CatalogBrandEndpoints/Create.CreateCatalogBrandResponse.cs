using System;

namespace Oyster.PublicApi.CatalogBrandEndpoints;

public class CreateCatalogBrandResponse : BaseResponse
{
    public CreateCatalogBrandResponse(Guid correlationId) : base(correlationId)
    {
    }

    public CreateCatalogBrandResponse()
    {
    }

    public CatalogBrandDto CatalogBrand { get; set; }
}
