using System;

namespace Oyster.PublicApi.CatalogBrandEndpoints;

public class UpdateCatalogBrandResponse : BaseResponse
{
    public UpdateCatalogBrandResponse(Guid correlationId) : base(correlationId)
    {
    }

    public UpdateCatalogBrandResponse()
    {
    }

    public CatalogBrandDto CatalogBrand { get; set; }
}
